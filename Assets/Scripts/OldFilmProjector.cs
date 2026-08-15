using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[DefaultExecutionOrder(10000)]
public class OldFilmProjector : MonoBehaviour
{
    [Header("Brightness Flicker")]
    public Volume globalVolume;
    public float flickerAmount = 0.08f;
    public float flickerSpeed = 7f;

    [Header("Gate Weave")]
    public float horizontalPixels = 0.4f;
    public float verticalPixels = 0.8f;
    public float weaveSpeed = 2.5f;

    private ColorAdjustments colorAdjustments;
    private Camera cam;

    private Vector3 previousOffset;

    private float flickerSeed;
    private float weaveSeedX;
    private float weaveSeedY;

    void Start()
    {
        cam = GetComponent<Camera>();

        flickerSeed = Random.Range(0f, 1000f);
        weaveSeedX = Random.Range(0f, 1000f);
        weaveSeedY = Random.Range(0f, 1000f);

        if (globalVolume != null)
        {
            globalVolume.profile.TryGet(out colorAdjustments);
        }
    }

    void LateUpdate()
    {
        float time = Time.unscaledTime;

        // -------------------------
        // BRIGHTNESS FLICKER
        // -------------------------
        if (colorAdjustments != null)
        {
            float noise =
                Mathf.PerlinNoise(
                    flickerSeed,
                    time * flickerSpeed
                );

            noise = (noise - 0.5f) * 2f;

            colorAdjustments.postExposure.value =
                noise * flickerAmount;
        }

        // -------------------------
        // GATE WEAVE
        // -------------------------

        // Remove last frame's visual offset first
        transform.localPosition -= previousOffset;

        float xNoise =
            (Mathf.PerlinNoise(
                weaveSeedX,
                time * weaveSpeed
            ) - 0.5f) * 2f;

        float yNoise =
            (Mathf.PerlinNoise(
                weaveSeedY,
                time * weaveSpeed * 0.83f
            ) - 0.5f) * 2f;

        if (cam.orthographic)
        {
            float unitsPerPixel =
                (cam.orthographicSize * 2f) / Screen.height;

            previousOffset = new Vector3(
                xNoise * horizontalPixels * unitsPerPixel,
                yNoise * verticalPixels * unitsPerPixel,
                0f
            );

            transform.localPosition += previousOffset;
        }
    }

    void OnDisable()
    {
        transform.localPosition -= previousOffset;

        if (colorAdjustments != null)
            colorAdjustments.postExposure.value = 0f;
    }
}