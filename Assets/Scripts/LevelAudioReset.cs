using UnityEngine;

public class LevelAudioReset : MonoBehaviour
{
    private void Awake()
    {
        AudioListener.pause = false;
        AudioListener.volume = 1f;
        Time.timeScale = 1f;
    }
}