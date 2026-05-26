using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class SkeletNPCDia : MonoBehaviour
{
    public GameObject speechBubble;
    public TMP_Text dialogueText;
    public GameObject freePopup;
    public TMP_Text popupText;
    public Button yesButton;
    public Button noButton;

    public string dialogue = "I am chained here... please find the key and free me!";
    public string dialogueWithKey = "You found the key!";
    public string dialogueFreed = "The gate in the cave is now open, go help the others!";
    public float popDuration = 0.2f;
    public float typeSpeed = 0.02f;
    public float freeDelay = 0f;

    private bool playerInRange = false;

    void Start()
    {
        speechBubble.SetActive(true);
        dialogueText.text = dialogue;
        speechBubble.transform.localScale = Vector3.zero;
        speechBubble.SetActive(false);
        freePopup.SetActive(false);

        yesButton.onClick.AddListener(OnYesClicked);
        noButton.onClick.AddListener(OnNoClicked);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            speechBubble.SetActive(true);
            StartCoroutine(PopIn());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            StopAllCoroutines();
            freePopup.transform.localScale = Vector3.zero;
            freePopup.SetActive(false);
            if (gameObject.activeInHierarchy)
            {
                StartCoroutine(PopOut());
            }
            else
            {
                speechBubble.SetActive(false);
            }
        }
    }

    IEnumerator PopIn()
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / popDuration;
            speechBubble.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            yield return null;
        }
        speechBubble.transform.localScale = Vector3.one;

        dialogueText.text = "";
        string currentDialogue = GameManager.instance.hasKey ? dialogueWithKey : dialogue;
        foreach (char letter in currentDialogue)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }

        if (GameManager.instance.hasKey && !GameManager.instance.npcFreed)
        {
            yield return new WaitForSeconds(freeDelay);
            popupText.text = "Give the key and free the skeleton?";
            freePopup.SetActive(true);
            StartCoroutine(PopupScaleIn());
        }
    }

    IEnumerator PopupScaleIn()
    {
        yesButton.interactable = false;
        noButton.interactable = false;
        float t = 0f;
        freePopup.transform.localScale = Vector3.zero;
        while (t < 1f)
        {
            t += Time.deltaTime / popDuration;
            freePopup.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(0.002f, 0.002f, 0.002f), t);
            yield return null;
        }
        freePopup.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        yesButton.interactable = true;
        noButton.interactable = true;
    }

    void OnYesClicked()
    {
        freePopup.transform.localScale = Vector3.zero;
        freePopup.SetActive(false);
        StartCoroutine(FreeNPC());
    }

    void OnNoClicked()
    {
        freePopup.transform.localScale = Vector3.zero;
        freePopup.SetActive(false);
    }

    IEnumerator FreeNPC()
    {
        dialogueText.text = "";
        foreach (char letter in dialogueFreed)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
        GameManager.instance.npcFreed = true;
    }

    IEnumerator PopOut()
    {
        dialogueText.text = "";
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / popDuration;
            speechBubble.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, t);
            yield return null;
        }
        speechBubble.SetActive(false);
    }
}