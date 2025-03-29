using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private Transform cameraTransform; // R�f�rence � la cam�ra
    [SerializeField] public Vector2 CurrentMovement { get; set; }
    [SerializeField] public bool IsMoving { get; set; } = true;

    public void OnMovement(InputAction.CallbackContext context)
    {
        CurrentMovement = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        if (!IsMoving) return;

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // On ignore la hauteur pour �viter des d�placements ind�sirables en Y
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Calcul du mouvement relatif � la cam�ra
        Vector3 movement = (right * CurrentMovement.x + forward * CurrentMovement.y).normalized;

        transform.Translate(_speed * movement * Time.fixedDeltaTime, Space.World);

        /*if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.fixedDeltaTime);
        }*/
    }
}
