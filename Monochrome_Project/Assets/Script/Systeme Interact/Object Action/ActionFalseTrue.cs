using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFalseTrue : MonoBehaviour
{
    private bool _isActive = true;
    [SerializeField] private Animator _animator;
    [SerializeField] private List<GameObject> _listGameObject;

    public void OnInteract()
    {
        if (!_isActive) return;
        _isActive = false;
        _animator.SetBool("Activate", !_animator.GetBool("Activate"));
        for (int i = 0; i < _listGameObject.Count; i++)
        {
            _listGameObject[i].SetActive(!_listGameObject[i]);
        }
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        _isActive = true;
    }
}
