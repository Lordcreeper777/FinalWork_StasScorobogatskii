using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerButtonEffect : MonoBehaviour,
    ISelectHandler,
    IDeselectHandler,
    ISubmitHandler
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

    public void OnSelect(BaseEventData eventData)
    {
        if (hoverDecoration != null)
            hoverDecoration.SetActive(true);

        if (audioSource != null && hoverSound != null)
            audioSource.PlayOneShot(hoverSound);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (hoverDecoration != null)
            hoverDecoration.SetActive(false);
    }

    public void OnSubmit(BaseEventData eventData)
    {
        if (audioSource != null && clickSound != null)
            audioSource.PlayOneShot(clickSound);
    }
}