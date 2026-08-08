using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerClickHandler
{
    public GameObject hoverDecoration;

    public AudioSource audioSource;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    private void OnEnable()
    {
        if (hoverDecoration != null)
            hoverDecoration.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverDecoration != null)
            hoverDecoration.SetActive(true);

        if (audioSource != null && hoverSound != null)
            audioSource.PlayOneShot(hoverSound);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverDecoration != null)
            hoverDecoration.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (audioSource != null && clickSound != null)
            audioSource.PlayOneShot(clickSound);
    }
}