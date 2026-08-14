using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class OpeningVideoEnd : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public SceneTransition sceneTransition;

    public float transitionBeforeEnd = 2f;

    private bool transitionStarted = false;

    private void Update()
    {
        if (!videoPlayer.isPlaying || transitionStarted)
            return;

        double timeRemaining = videoPlayer.length - videoPlayer.time;

        if (timeRemaining <= transitionBeforeEnd)
        {
            transitionStarted = true;
            StartCoroutine(FadeAudioAndTransition());
        }
    }

    private IEnumerator FadeAudioAndTransition()
    {
        float startVolume = AudioListener.volume;
        float timer = 0f;

        // Start the screen fade
        sceneTransition.LoadScene("Level 1");

        // Slowly mute all audio during the transition
        while (timer < transitionBeforeEnd)
        {
            timer += Time.unscaledDeltaTime;

            float t = timer / transitionBeforeEnd;

            AudioListener.volume = Mathf.Lerp(startVolume, 0f, t);

            yield return null;
        }

        AudioListener.volume = 0f;
    }
}