using System;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Exécute une fonction spécifique sur un GameObject cible.
/// </summary>
[Serializable]
public class CallFunctionAction : InteractionAction
{
    [Tooltip("L'objet qui contient le script et la fonction à appeler")]
    [SerializeField] private GameObject targetObject;

    [Tooltip("Nom du script où se trouve la fonction")]
    [SerializeField] private string scriptName;

    [Tooltip("Nom de la fonction à exécuter")]
    [SerializeField] private string functionName;

    public override Task<int> Execute()
    {
        if (targetObject == null || string.IsNullOrEmpty(scriptName) || string.IsNullOrEmpty(functionName))
        {
            Debug.LogWarning("CallFunctionAction : Paramètres manquants !");
            return Task.FromResult(0);
        }

        Component targetScript = targetObject.GetComponent(scriptName);
        if (targetScript == null)
        {
            Debug.LogWarning($"CallFunctionAction : Le script '{scriptName}' n'existe pas sur {targetObject.name}");
            return Task.FromResult(0);
        }

        MethodInfo method = targetScript.GetType().GetMethod(functionName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (method != null)
        {
            method.Invoke(targetScript, null);
        }
        else
        {
            Debug.LogWarning($"CallFunctionAction : La fonction '{functionName}' n'existe pas dans '{scriptName}' !");
        }

        return Task.FromResult(0);
    }
}
