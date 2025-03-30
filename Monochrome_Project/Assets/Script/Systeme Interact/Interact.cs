using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    private GameObject _objectInteract;

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && _objectInteract != null)
        {
            _objectInteract.SendMessage("OnInteract");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjectInteract"))
        {
            _objectInteract = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ObjectInteract"))
        {
            _objectInteract = null;
        }
    }
}
