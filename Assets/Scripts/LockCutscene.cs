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
    private void Update()
{
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

    AudioListener.pause = true;

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