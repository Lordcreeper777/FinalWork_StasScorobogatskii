using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform teleportTarget;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportTarget.position;
        }
    }
}
