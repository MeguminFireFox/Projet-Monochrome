using System;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// A simple JMP instruction. Jump to another point in the interaction
/// </summary>
[Serializable]
public class JumpAction : InteractionAction
{
    [Tooltip("The action you want to jump to in the interaction")]
    [SerializeField] private int _pc;
    
    /// <inheritdoc cref="HarmonyActions.Execute"/>
    public override Task<int> Execute()
    {
        // Just return where to jump.
        return Task.FromResult(_pc);
    }
}