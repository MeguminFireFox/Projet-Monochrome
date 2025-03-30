using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [SerializeField] public bool CanJump { get; set; } = true;
    [SerializeField] public bool IsJump { get; set; } = true;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _jump = false;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _collisionLayer;
    [SerializeField] private LayerMask _verifSol;
    [SerializeField] private Animator _animator;
    private Collider[] _colliders;

    private void Update()
    {
        if (CanJump)
        {
            _jump = Physics.OverlapSphere(_groundCheck.position, _radius, _collisionLayer).Length > 0;
            _colliders = Physics.OverlapSphere(_groundCheck.position, _radius, _collisionLayer);
            _animator.SetBool("IsJump", !_jump);

            if (_jump)
            {
                _rb.velocity = Vector3.zero;
            }
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!CanJump || !IsJump) return;

        foreach (Collider collider in _colliders)
        {
            if (context.performed && _jump && collider.gameObject != this.gameObject)
            {
                _animator.SetBool("Jump", true);

                ActiveJump();
            }
        }
    }

    public void ActiveJump()
    {
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        CanJump = false;
        _jump = false;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        _animator.SetBool("Jump", false);
        CanJump = true;
    }

    void OnDrawGizmos()
    {
        if (_groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_groundCheck.position, _radius);
        }
    }
}
