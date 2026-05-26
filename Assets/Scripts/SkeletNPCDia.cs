using UnityEngine;
using TMPro;
using System.Collections;

public class SkeletNPCDia : MonoBehaviour
{
    public GameObject speechBubble;
    public TMP_Text dialogueText;
    public string dialogue = "I am chained here... please find the key and free me!";
    public string dialogueWithKey = "You found the key! Please free me!";
    public float popDuration = 0.2f;
    public float typeSpeed = 0.05f;

    void Start()
    {
        speechBubble.SetActive(true);
        dialogueText.text = dialogue;
        speechBubble.transform.localScale = Vector3.zero;
        speechBubble.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            speechBubble.SetActive(true);
            StartCoroutine(PopIn());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(PopOut());
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