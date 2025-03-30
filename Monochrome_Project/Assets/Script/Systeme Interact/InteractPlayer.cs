using System.Threading.Tasks;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Object that play interaction
/// </summary>

public class InteractionPlayer
{
    private static bool isInteractionPlaying;
    private static string _currentInteractionName;

    private static int _currentlyStoredPriority;

    /// <summary>
    /// Play an interaction, play the actions and jump when appropriate.
    /// </summary>
    /// <param name="data"> The interaction itself </param>
    public static async Task<int> PlayInteraction(InteractionData data, int priority = 1)
    {
        if (!isInteractionPlaying || _currentlyStoredPriority < priority)
        {
            _currentlyStoredPriority = priority;
            isInteractionPlaying = true;
            _currentInteractionName = data.name;
            for (int programCounter = 0; programCounter < data.Actions.Length; programCounter++)
            {
#if UNITY_EDITOR
                if (!EditorApplication.isPlaying) return -2;
#endif
                if (_currentlyStoredPriority > priority) return -3;

                int response = await data.Actions[programCounter].Execute();

                if (response == 0) continue;
                if (response == -1)
                {
                    programCounter--;
                    continue;
                }

                if (response == -10)
                {
                    break;
                }

                programCounter = response - 1;
            }
            isInteractionPlaying = false;
            _currentInteractionName = "";

            return 0;
        }
        Debug.LogWarning("Trying to play interaction" + data.name + "but + " + _currentInteractionName + " is already playing");
        return -1;
    }
}