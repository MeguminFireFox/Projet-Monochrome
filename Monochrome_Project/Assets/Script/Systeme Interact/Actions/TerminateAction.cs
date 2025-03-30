using System.Threading.Tasks;

/// <summary>
/// Finish an interaction.
/// </summary>
public class TerminateAction : InteractionAction
{
    public override Task<int> Execute()
    {
        // -10 is the opcode for terminating an interaction, so HarmonyInteractionPlayer know to halt all.
        return Task.FromResult(-10);
    }
}