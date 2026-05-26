using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float hoverScale = 1.1f;
    public float speed = 8f;
    public TMP_Text buttonText;
    public float glowPower = 0.8f;
    public float glowOffset = 0.1f;

    private Vector3 originalScale;
    private Vector3 targetScale;
    private float targetGlowPower = 0f;
    private float targetGlowOffset = 0f;
    private Material textMaterial;

    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;

        if (buttonText != null)
        {
            textMaterial = new Material(buttonText.fontMaterial);
            buttonText.fontMaterial = textMaterial;
            textMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 0f);
            textMaterial.SetFloat(ShaderUtilities.ID_GlowOffset, 0f);
        }
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * speed);

        if (textMaterial != null)
        {
            float currentPower = textMaterial.GetFloat(ShaderUtilities.ID_GlowPower);
            float currentOffset = textMaterial.GetFloat(ShaderUtilities.ID_GlowOffset);

            textMaterial.SetFloat(ShaderUtilities.ID_GlowPower,
                Mathf.Lerp(currentPower, targetGlowPower, Time.deltaTime * speed));
            textMaterial.SetFloat(ShaderUtilities.ID_GlowOffset,
                Mathf.Lerp(currentOffset, targetGlowOffset, Time.deltaTime * speed));
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == gameObject ||
            eventData.pointerCurrentRaycast.gameObject?.transform.parent?.gameObject == gameObject)
        {
            targetScale = originalScale * hoverScale;
            targetGlowPower = glowPower;
            targetGlowOffset = glowOffset;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = originalScale;
        targetGlowPower = 0f;
        targetGlowOffset = 0f;
    }
}