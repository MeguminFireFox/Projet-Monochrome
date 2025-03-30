using UnityEngine;
using TMPro;
using System.Collections;
using Cysharp.Threading.Tasks;

public class TextInteract : MonoBehaviour
{
    public static TextInteract Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _interactText;
    private Coroutine typingCoroutine;
    private Coroutine hideCoroutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async UniTask ShowText(string text, float duration = 2f)
    {
        if (_interactText == null) return;

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        _interactText.text = "";
        _interactText.gameObject.SetActive(true);
        typingCoroutine = StartCoroutine(TypeText(text, duration));
        await UniTask.WaitUntil(() => typingCoroutine != null);
    }

    private IEnumerator TypeText(string text, float duration)
    {
        float typingSpeed = CalculateTypingSpeed(text, duration);

        foreach (char letter in text.ToCharArray())
        {
            _interactText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        hideCoroutine = StartCoroutine(HideAfterDelay(duration));
    }

    private float CalculateTypingSpeed(string text, float duration)
    {
        float typingDuration = duration * 0.2f;
        return text.Length > 0 ? typingDuration / text.Length : 0.01f;
    }

    private IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay * 0.8f);
        _interactText.gameObject.SetActive(false);
    }
}