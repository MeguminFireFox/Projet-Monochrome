using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Transform))]
public class ObjectOnGround : Editor
{
    private Editor defaultEditor;
    public float raycastDistance = 1000f;
    public LayerMask groundLayer = ~0; // Détecte tout par défaut

    private void OnEnable()
    {
        var inspectorType = Type.GetType("UnityEditor.TransformInspector, UnityEditor");
        if (inspectorType != null)
        {
            defaultEditor = CreateEditor(target, inspectorType);
        }
    }

    private void OnDisable()
    {
        if (defaultEditor != null)
        {
            DestroyImmediate(defaultEditor);
        }
    }

    public override void OnInspectorGUI()
    {
        if (defaultEditor != null)
        {
            defaultEditor.OnInspectorGUI();
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Placer au sol", GUILayout.Height(20)))
        {
            foreach (var obj in Selection.transforms)
            {
                PlaceOnGround(obj);
            }
        }
    }

    private void PlaceOnGround(Transform transform)
    {
        if (transform == null) return;

        float objectHeight = GetObjectHeight(transform);
        Vector3 startPosition = transform.position;

        RaycastHit hit;
        if (Physics.Raycast(startPosition, Vector3.down, out hit, raycastDistance, groundLayer, QueryTriggerInteraction.Ignore))
        {
            transform.position = hit.point + new Vector3(0, objectHeight, 0);
        }
        else
        {
            Debug.LogWarning($"Aucune surface détectée sous l'objet {transform.name}.");
        }
    }

    private float GetObjectHeight(Transform transform)
    {
        Collider collider = transform.GetComponentInChildren<Collider>();
        if (collider != null)
        {
            return collider.bounds.extents.y;
        }

        Renderer renderer = transform.GetComponentInChildren<Renderer>();
        if (renderer != null)
        {
            return renderer.bounds.extents.y;
        }

        return transform.localScale.y * 0.5f;
    }
}
