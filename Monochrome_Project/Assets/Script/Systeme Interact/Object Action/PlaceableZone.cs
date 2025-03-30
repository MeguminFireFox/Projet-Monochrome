using UnityEngine;

public class PlaceableZone : MonoBehaviour
{
    [SerializeField] private GameObject requiredObject; // L'objet attendu pour �tre pos�
    [SerializeField] private Transform placePosition;  // Position exacte o� l'objet sera pos�
    private bool isObjectPlaced = false;  // Pour s'assurer qu'on ne place l'objet qu'une seule fois
    [SerializeField] private Animator _animator;

    private void OnTriggerStay(Collider other)
    {
        // V�rifie que l'objet est celui qu'on veut et qu'il n'est pas d�j� pos�
        if (other.CompareTag("PickableObject") && !isObjectPlaced && Vector3.Distance(other.transform.position, transform.position) < 1f)
        {
            PlaceObject(other.gameObject);
        }
    }

    private void PlaceObject(GameObject obj)
    {
        if (obj == requiredObject) // V�rifie que l'objet est le bon
        {
            Rigidbody objRb = obj.GetComponent<Rigidbody>();
            if (objRb)
            {
                objRb.isKinematic = true; // D�sactive la physique
                objRb.useGravity = false; // D�sactive la gravit�
                objRb.detectCollisions = false; // D�sactive les collisions
            }

            obj.transform.position = placePosition.position; // Place l'objet pr�cis�ment
            obj.transform.rotation = placePosition.rotation; // Aligne l'objet avec la position et rotation du pilier
            obj.tag = "PlacedObject"; // Change son tag pour �viter qu'il soit repris

            isObjectPlaced = true; // L'objet est maintenant pos� et ne peut plus �tre repris
            _animator.SetBool("Activate", true);

            Debug.Log("Objet plac� avec succ�s !");
        }
    }
}
