using UnityEngine;
using System.Collections;

public class AreaSound : MonoBehaviour
{
    public float fadeDuration = 5f;
    public float maxVolume = 0.5f;

    private AudioSource audioSource;
    private Coroutine fadeCoroutine;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (fadeCoroutine != null)
                StopCoroutine(fadeCoroutine);

            if (!audioSource.isPlaying)
                audioSource.Play();

            fadeCoroutine = StartCoroutine(FadeAudio(maxVolume));
        }
    }

    void OnTriggerExit2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        if (!gameObject.activeInHierarchy)
            return;

        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeOutAndStop());
    }
}

    IEnumerator FadeAudio(float targetVolume)
    {
        float startVolume = audioSource.volume;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            audioSource.volume =
                Mathf.Lerp(startVolume, targetVolume, time / fadeDuration);

            yield return null;
        }

        audioSource.volume = targetVolume;
    }

    IEnumerator FadeOutAndStop()
    {
        float startVolume = audioSource.volume;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            audioSource.volume =
                Mathf.Lerp(startVolume, 0f, time / fadeDuration);

            yield return null;
        }

        audioSource.volume = 0f;
        audioSource.Stop();
    }
}