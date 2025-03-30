using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionLoadScene : MonoBehaviour
{
    private bool _isActive = true;
    //[SerializeField] private Animator _animator;
    [SerializeField] private List<GameObject> _listGameObject;
    [SerializeField] private string _nameScene;

    public void OnInteract()
    {
        if (!_isActive) return;
        _isActive = false;

        /*bool newState = !_animator.GetBool("Activate");
        _animator.SetBool("Activate", newState);*/

        for (int i = 0; i < _listGameObject.Count; i++)
        {
            _listGameObject[i].SetActive(!_listGameObject[i].activeSelf);
        }

        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(_nameScene);
        _isActive = true;
    }
}
