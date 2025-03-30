using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] public Vector2 CurrentMovement { get; set; }
    [SerializeField] public bool IsMoving { get; set; } = true;
    [SerializeField] private Animator _animator;

    public int MovementDirection { get; private set; } = 0;

    public void OnMovement(InputAction.CallbackContext context)
    {
        CurrentMovement = context.ReadValue<Vector2>();

        if (!IsMoving) return;

        if (CurrentMovement.x > 0)
            MovementDirection = 1;  // Droite
        else if (CurrentMovement.x < 0)
            MovementDirection = -1; // Gauche
    }

    void FixedUpdate()
    {
        if (!IsMoving)
        {
            _animator.SetBool("Move", false);
            return;
        }

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = (right * CurrentMovement.x + forward * CurrentMovement.y).normalized;

        transform.Translate(_speed * movement * Time.fixedDeltaTime, Space.World);

        if (movement != Vector3.zero)
        {
            _animator.SetBool("Move", true);
        }
        else
        {
            _animator.SetBool("Move", false);
        }
    }
}
