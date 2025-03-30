using System.Collections;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    [SerializeField] private InteractionData _data;
    private bool _isActive = true;

    public async void OnInteract()
    {
        if (!_isActive) return;
        _isActive = false;
        await InteractionPlayer.PlayInteraction(_data);
        _isActive = true;
    }
}