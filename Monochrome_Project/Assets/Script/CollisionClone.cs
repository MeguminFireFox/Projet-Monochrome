using UnityEngine;

public class CollisionClone : MonoBehaviour
{
    [SerializeField] private Swap _swap;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Clone")
        {
            _swap.Colision = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Clone")
        {
            _swap.Colision = false;
        }
    }
}
