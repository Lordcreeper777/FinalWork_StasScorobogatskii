using UnityEngine;
using UnityEngine.Video;

public class CheckVideoSpeed : MonoBehaviour
{
    public float speed = 0.05f;

    private VideoPlayer videoPlayer;

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.playOnAwake = false;
        videoPlayer.skipOnDrop = false;

        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.Prepare();
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        vp.playbackSpeed = speed;
        vp.Play();

        Debug.Log("Video playing at: " + vp.playbackSpeed);
    }

    void OnDestroy()
    {
        videoPlayer.prepareCompleted -= OnVideoPrepared;
    }
}