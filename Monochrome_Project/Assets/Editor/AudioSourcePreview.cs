using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AudioSource))]
public class AudioSourcePreview : Editor
{
    private Editor defaultEditor;

    private void OnEnable()
    {
        var inspectorType = Type.GetType("UnityEditor.AudioSourceInspector, UnityEditor");
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

        AudioSource audioSource = (AudioSource)target;
        if (GUILayout.Button("Tester l'audio", GUILayout.Height(20)))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            audioSource.Play();
        }
    }
}
