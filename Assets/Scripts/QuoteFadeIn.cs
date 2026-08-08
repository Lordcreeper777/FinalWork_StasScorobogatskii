using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class QuoteFadeIn : MonoBehaviour
{
    public float fadeDuration = 1.5f;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1f;
    }

    private IEnumerator Start()
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.unscaledDeltaTime;

            canvasGroup.alpha =
                1f - Mathf.Clamp01(time / fadeDuration);

            yield return null;
        }

        canvasGroup.alpha = 0f;
    }
}