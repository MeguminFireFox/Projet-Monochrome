using UnityEngine;

public class TurnTowardCamera : MonoBehaviour
{
    private Camera mainCamera;
    public Vector3 generalDirection = Vector3.forward; // Direction g�n�rale de l'objet

    // Start is called before the first frame update
    void Start()
    {
        // R�cup�re la cam�ra principale de la sc�ne
        mainCamera = Camera.main;
    }

    // Update is called une fois par frame
    void Update()
    {
        if (mainCamera != null)
        {
            // Applique un billboard complet (toujours face � la cam�ra)
            transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward, mainCamera.transform.up);
        }
    }
}
