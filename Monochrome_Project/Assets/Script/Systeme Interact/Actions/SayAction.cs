using System;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class SayAction : InteractionAction
{
    [SerializeField] private string _text;
    [SerializeField] private float _time;
    
    public override async Task<int> Execute()
    {
        await TextInteract.Instance.ShowText(_text, _time);
        return 0;
    }
}
