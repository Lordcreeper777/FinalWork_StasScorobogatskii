using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class SceneTransition : MonoBehaviour
{
    public float fadeDuration = 1f;
    public bool fadeInOnStart = false;

    private CanvasGroup canvasGroup;
    private bool isTransitioning = false;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        if (fadeInOnStart)
        {
            canvasGroup.alpha = 1f;
            StartCoroutine(FadeIn());
        }
        else
        {
            canvasGroup.alpha = 0f;
        }
    }

    public void LoadScene(string sceneName)
    {
        if (!isTransitioning)
        {
            StartCoroutine(FadeOutAndLoad(sceneName));
        }
    }

    private IEnumerator FadeIn()
    {
        while (canvasGroup.alpha > 0f)
        {
            canvasGroup.alpha -= Time.unscaledDeltaTime / fadeDuration;
            yield return null;
        }

        canvasGroup.alpha = 0f;
    }

    private IEnumerator FadeOutAndLoad(string sceneName)
    {
        isTransitioning = true;

        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.unscaledDeltaTime / fadeDuration;
            yield return null;
        }

        canvasGroup.alpha = 1f;

        SceneManager.LoadScene(sceneName);
    }
}