using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Swap : MonoBehaviour
{
    [SerializeField] private List<Movement> _listMovement;
    [SerializeField] private List<Jump> _listJump;
    [SerializeField] private GameObject _playerClone;
    [SerializeField] private Transform _playerTransform;
    private int _index = 0;

    // Ajout d'une variable pour suivre si le clone est actif
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

        // 1?? Si on contrôle le joueur et on est en collision avec le clone ? désactivation du clone
        if (_index == 0 && _cloneActive && Colision)
        {
            Debug.Log("Collision détectée, le joueur désactive le clone.");
            _playerClone.SetActive(false);
            _cloneActive = false;
            Colision = false; // Réinitialiser la collision
            return;
        }

        // 2?? Si le clone n'est pas actif ? On le fait apparaître et on prend son contrôle
        if (!_cloneActive)
        {
            Debug.Log("Le clone n'est pas actif, on le fait apparaître et on prend le contrôle.");
            _playerClone.transform.position = _playerTransform.position + new Vector3(1, 0, 0); // Apparaît à côté
            _playerClone.SetActive(true);
            _cloneActive = true;
            SwitchControl(1); // On passe au clone
            return;
        }

        // 3?? Si on contrôle le clone et qu'on fait l'action ? On revient au joueur principal
        if (_index == 1)
        {
            Debug.Log("On contrôle le clone, on revient au joueur principal.");
            SwitchControl(0);
            return;
        }

        // 4?? Si on contrôle le joueur et que le clone est actif mais sans collision ? Switch entre les deux
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
