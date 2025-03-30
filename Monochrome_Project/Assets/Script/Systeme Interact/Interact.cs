using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    private GameObject _objectInteract;
    private Rigidbody _heldRigidbody;
    private Vector3 _initialLocalPosition;
    [SerializeField] private Transform _player;
    [SerializeField] private float followSpeed = 10f; // Vitesse de suivi

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_heldRigidbody != null)
            {
                Drop();
                return;
            }

            if (_objectInteract != null && _objectInteract.CompareTag("PickableObject"))
            {
                PickUp(_objectInteract);
            }
            else if (_objectInteract != null)
            {
                _objectInteract.SendMessage("OnInteract", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    private void PickUp(GameObject obj)
    {
        _heldRigidbody = obj.GetComponent<Rigidbody>();
        if (_heldRigidbody == null) return;

        _initialLocalPosition = _player.InverseTransformPoint(_heldRigidbody.position);
        _initialLocalPosition.y += 0.5f; // Soulève légèrement

        _heldRigidbody.useGravity = false; // Désactive la gravité mais garde la physique
        _heldRigidbody.drag = 10f; // Augmente la friction pour éviter les mouvements brusques

        Debug.Log("Objet ramassé : " + obj.name);
    }

    private void Drop()
    {
        _heldRigidbody.useGravity = true; // Réactive la gravité
        _heldRigidbody.drag = 1f; // Remet la friction par défaut
        _heldRigidbody = null; // Libère l'objet

        Debug.Log("Objet lâché !");
    }

    private void FixedUpdate()
    {
        if (_heldRigidbody != null)
        {
            Vector3 targetPosition = _player.TransformPoint(_initialLocalPosition);
            _heldRigidbody.MovePosition(Vector3.Lerp(_heldRigidbody.position, targetPosition, followSpeed * Time.fixedDeltaTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjectInteract") || other.CompareTag("PickableObject"))
        {
            _objectInteract = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_objectInteract == other.gameObject)
        {
            _objectInteract = null;
        }
    }
}
