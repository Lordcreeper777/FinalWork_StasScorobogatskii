using UnityEngine;

public class Hazard : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAudio playerAudio = other.GetComponent<PlayerAudio>();

            if (playerAudio != null)
            {
                playerAudio.SetRunning(false);
                playerAudio.PlayDeath();
            }

            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }

            other.transform.position = GameManager.instance.respawnPoint.position;
        }
    }
}