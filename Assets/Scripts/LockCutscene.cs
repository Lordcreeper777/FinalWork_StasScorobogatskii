using UnityEngine;
using UnityEngine.Video;

public class LockCutscene : MonoBehaviour
{
    public SkeletNPCDia npcDialogue;
    public GameObject speechBubble;
    public GameObject cutsceneObject;
    public VideoPlayer videoPlayer;

    // Drag NPC-Folder here in the Inspector
    public GameObject npcRoot;

    private bool alreadyUsed = false;

    private void Start()
    {
        cutsceneObject.SetActive(false);
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnMouseDown()
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

        // Show and play the cutscene
        cutsceneObject.SetActive(true);
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

        // Remove the whole NPC setup
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