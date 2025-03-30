using System;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Base class for every type of action in the game
/// </summary>
[Serializable]
public abstract class InteractionAction
{
    /// <summary>
    /// Initialize data for the payload to be sure everything is set up correctly before running
    /// </summary>
    public virtual void Initialize() {}
    
    /// <summary>
    /// Execute the action
    /// </summary>
    /// <returns> Where to jump in the interaction </returns>
    public abstract Task<int> Execute();
}
