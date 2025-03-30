using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float raycastDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;

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
}
