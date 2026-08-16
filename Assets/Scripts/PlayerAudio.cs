using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioSource runSource;

    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip runSound;

    private void Start()
    {
        runSource.clip = runSound;
        runSource.loop = true;
    }

    public void PlayJump()
    {
        if (jumpSound != null)
            sfxSource.PlayOneShot(jumpSound);
    }

    public void PlayDeath()
    {
        if (deathSound != null)
            sfxSource.PlayOneShot(deathSound);
    }

    public void SetRunning(bool running)
    {
        if (running)
        {
            if (!runSource.isPlaying)
                runSource.Play();
        }
        else
        {
            if (runSource.isPlaying)
                runSource.Stop();
        }
    }
}