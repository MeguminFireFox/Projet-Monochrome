using UnityEngine;

public class Velocity : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float raycastDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [field: SerializeField] public Vector3 ZoneRespawn { get; set; }

    private void Update()
    {
        if (!IsGrounded())
        {
            _animator.SetFloat("Velocity y", _rb.velocity.y);
        }
        else
        {
            _animator.SetFloat("Velocity y", 0);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance, groundLayer);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "ZoneDeath")
        {
            _rb.velocity = Vector3.zero;
            transform.position = ZoneRespawn;
        }
    }
}
