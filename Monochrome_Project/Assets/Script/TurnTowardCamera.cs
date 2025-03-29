using UnityEngine;

public class TurnTowardCamera : MonoBehaviour
{
    private Camera mainCamera;
    public Vector3 generalDirection = Vector3.forward; // Direction générale de l'objet

    // Start is called before the first frame update
    void Start()
    {
        // Récupère la caméra principale de la scène
        mainCamera = Camera.main;
    }

    // Update is called une fois par frame
    void Update()
    {
        if (mainCamera != null)
        {
            // Applique un billboard complet (toujours face à la caméra)
            transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward, mainCamera.transform.up);
        }
    }
}
