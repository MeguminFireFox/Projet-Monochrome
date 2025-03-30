using UnityEngine;

/// <summary>
/// An interaction, a list of Actions and a condition for activation
/// </summary>
[CreateAssetMenu(fileName = "Interaction", menuName = "Tanktical/Interaction Data", order = 0)]
public class InteractionData : ScriptableObject
{
    /// <summary>
    /// The list of actions.
    /// </summary>
    [SerializeReference, SerializeReferenceButton] public InteractionAction[] Actions;
}