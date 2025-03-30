using UnityEngine;

public class PlaceableZone : MonoBehaviour
{
    [SerializeField] private GameObject requiredObject; // L'objet attendu pour être posé
    [SerializeField] private Transform placePosition;  // Position exacte où l'objet sera posé
    private bool isObjectPlaced = false;  // Pour s'assurer qu'on ne place l'objet qu'une seule fois
    [SerializeField] private Animator _animator;

    private void OnTriggerStay(Collider other)
    {
        // Vérifie que l'objet est celui qu'on veut et qu'il n'est pas déjà posé
        if (other.CompareTag("PickableObject") && !isObjectPlaced && Vector3.Distance(other.transform.position, transform.position) < 1f)
        {
            PlaceObject(other.gameObject);
        }
    }

    private void PlaceObject(GameObject obj)
    {
        if (obj == requiredObject) // Vérifie que l'objet est le bon
        {
            Rigidbody objRb = obj.GetComponent<Rigidbody>();
            if (objRb)
            {
                objRb.isKinematic = true; // Désactive la physique
                objRb.useGravity = false; // Désactive la gravité
                objRb.detectCollisions = false; // Désactive les collisions
            }

            obj.transform.position = placePosition.position; // Place l'objet précisément
            obj.transform.rotation = placePosition.rotation; // Aligne l'objet avec la position et rotation du pilier
            obj.tag = "PlacedObject"; // Change son tag pour éviter qu'il soit repris

            isObjectPlaced = true; // L'objet est maintenant posé et ne peut plus être repris
            _animator.SetBool("Activate", true);

            Debug.Log("Objet placé avec succès !");
        }
    }
}
