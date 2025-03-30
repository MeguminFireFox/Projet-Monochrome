using UnityEngine;

public class TurnTowardCamera1 : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private Movement _movement;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (mainCamera != null && _movement != null)
        {
            Quaternion currentRotation = transform.rotation;

            Quaternion targetRotation = Quaternion.LookRotation(mainCamera.transform.forward, Vector3.up);

            if (_movement.MovementDirection == -1)
            {
                targetRotation = Quaternion.Euler(targetRotation.eulerAngles.x, targetRotation.eulerAngles.y + 180, targetRotation.eulerAngles.z);
            }

            transform.rotation = Quaternion.Euler(currentRotation.eulerAngles.x, targetRotation.eulerAngles.y, currentRotation.eulerAngles.z);
        }
    }
}
