using UnityEngine;

public class Gate : MonoBehaviour
{
    private BoxCollider2D gateCollider;
    private SpriteRenderer gateRenderer;

    void Start()
    {
        gateCollider = GetComponent<BoxCollider2D>();
        gateRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (GameManager.instance.npcFreed)
        {
            gateCollider.enabled = false;
            gateRenderer.enabled = false;
        }
    }
}