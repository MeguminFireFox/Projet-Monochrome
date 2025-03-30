using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Swap : MonoBehaviour
{
    [SerializeField] private List<Movement> _listMovement;
    [SerializeField] private List<Jump> _listJump;
    [SerializeField] private GameObject _playerClone;
    [SerializeField] private GameObject _spriteClone; // Le sprite du clone
    [SerializeField] private Collider _cloneCollider; // Le collider du clone
    [SerializeField] private Rigidbody _cloneRigidbody; // Le Rigidbody du clone
    [SerializeField] private Transform _playerTransform;

    private int _index = 0;
    private bool _cloneActive = false;
    [SerializeField] private bool colision;
    public bool Colision { get => colision; set => colision = value; }

    public void OnSwap(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SwapController();
        }
    }

    private void SwapController()
    {
        Debug.Log($"Swap action triggered - Current Index: {_index}, Clone Active: {_cloneActive}, Collision: {Colision}");

        // Si on contrôle le joueur et qu'on est en collision avec le clone, désactive sprite + collider
        if (_index == 0 && _cloneActive && Colision)
        {
            Debug.Log("Collision détectée, on désactive le sprite et le collider du clone.");
            if (_spriteClone != null) _spriteClone.SetActive(false);
            if (_cloneCollider != null) _cloneCollider.enabled = false;

            _cloneActive = false;
            Colision = false; // Réinitialiser la collision
            return;
        }

        // Si le clone n'est pas actif, on le réactive
        if (!_cloneActive)
        {
            Debug.Log("Le clone n'est pas actif, on réactive son sprite et son collider.");

            // Remettre sa vélocité à zéro pour éviter les mouvements non désirés
            if (_cloneRigidbody != null) _cloneRigidbody.velocity = Vector3.zero;

            _playerClone.transform.position = _playerTransform.position + new Vector3(1, 0, 0); // Apparaît à côté

            if (_spriteClone != null) _spriteClone.SetActive(true);
            if (_cloneCollider != null) _cloneCollider.enabled = true;

            _cloneActive = true;
            SwitchControl(1); // On passe au clone
            return;
        }

        // Si on contrôle le clone et qu'on fait l'action, on revient au joueur principal
        if (_index == 1)
        {
            Debug.Log("On contrôle le clone, on revient au joueur principal.");
            SwitchControl(0);
            return;
        }

        // Si on contrôle le joueur et que le clone est actif mais sans collision, switch entre les deux
        if (_index == 0 && _cloneActive)
        {
            Debug.Log("On contrôle le joueur et le clone est là, échange des contrôles.");
            SwitchControl(1);
        }
    }

    private void SwitchControl(int newIndex)
    {
        _listMovement[_index].IsMoving = false;
        _listJump[_index].IsJump = false;

        _listMovement[newIndex].IsMoving = true;
        _listJump[newIndex].IsJump = true;

        _index = newIndex;
        Debug.Log($"Contrôle basculé vers index {_index}");
    }
}
