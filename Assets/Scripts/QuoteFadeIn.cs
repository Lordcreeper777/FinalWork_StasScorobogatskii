using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class QuoteFadeIn : MonoBehaviour
{
    public float fadeDuration = 1.5f;

    private CanvasGroup canvasGroup;
    private bool isTransitioning = false;

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
            canvasGroup.alpha = 1f - Mathf.Clamp01(time / fadeDuration);

            yield return null;
        }

        canvasGroup.alpha = 0f;
    }

    public void LoadScene(string sceneName)
    {
        if (!isTransitioning)
        {
            StartCoroutine(FadeOutAndLoad(sceneName));
        }
    }

    private IEnumerator FadeOutAndLoad(string sceneName)
    {
        isTransitioning = true;

        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.unscaledDeltaTime;
            canvasGroup.alpha = Mathf.Clamp01(time / fadeDuration);

            yield return null;
        }

        canvasGroup.alpha = 1f;

        SceneManager.LoadScene(sceneName);
    }
}