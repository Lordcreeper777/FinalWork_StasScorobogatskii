using UnityEngine;
using UnityEngine.Video;

public class LockCutscene : MonoBehaviour
{
    public SkeletNPCDia npcDialogue;
    public GameObject speechBubble;

    public GameObject cutsceneObject;
    public VideoPlayer videoPlayer;

    public GameObject npcRoot;

    [Header("WebGL Video")]
    public string webGLVideoFileName = "MrBones_CutScene.mp4";

    private bool alreadyUsed = false;

    private void Start()
    {
        cutsceneObject.SetActive(false);

#if UNITY_WEBGL && !UNITY_EDITOR

        videoPlayer.source = VideoSource.Url;

        videoPlayer.url =
            Application.streamingAssetsPath + "/" + webGLVideoFileName;

        videoPlayer.audioOutputMode = VideoAudioOutputMode.Direct;

        videoPlayer.controlledAudioTrackCount = 1;
        videoPlayer.EnableAudioTrack(0, true);

#endif

        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void Update()
    {
        // Circle button on controller
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            TryInteract();
        }
    }

    private void OnMouseDown()
    {
        TryInteract();
    }

    private void TryInteract()
    {
        if (alreadyUsed)
            return;

        if (!GameManager.instance.hasKey)
            return;

        if (!npcDialogue.PlayerInRange)
            return;

        alreadyUsed = true;

        speechBubble.SetActive(false);

        // Pause normal game audio
        AudioListener.pause = true;

        // Show cutscene
        cutsceneObject.SetActive(true);

        // Play video
        videoPlayer.Play();
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        // Restore normal game audio
        AudioListener.pause = false;

        // NPC has been freed
        GameManager.instance.npcFreed = true;

        // Hide cutscene
        cutsceneObject.SetActive(false);

        // Remove NPC setup
        npcRoot.SetActive(false);
    }

    private void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoFinished;
        }
    }
}