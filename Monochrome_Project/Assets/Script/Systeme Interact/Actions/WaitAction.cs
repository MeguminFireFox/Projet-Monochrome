using System;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class WaitAction : InteractionAction
{
    [SerializeField]
    private float _time;
    
    public override async Task<int> Execute()
    {
        await Task.Delay((int)(_time * 1000));
        return 0;
    }
}
