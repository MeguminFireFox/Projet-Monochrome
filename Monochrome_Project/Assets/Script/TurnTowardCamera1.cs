using UnityEngine;

public class TurnTowardCamera1 : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (mainCamera != null)
        {
            Quaternion currentRotation = transform.rotation;

            transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward, Vector3.up);

            transform.rotation = Quaternion.Euler(currentRotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
    }
}
