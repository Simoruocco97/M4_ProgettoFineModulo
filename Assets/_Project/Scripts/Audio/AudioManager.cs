using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource, backgroundSound;
    [SerializeField] private AudioClip coinPickup, playerDamageSound, gameOverSound, winningSound;

    private void Awake()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void PlayPlayerDamageSound()
    {
        if (playerDamageSound != null)
            audioSource.PlayOneShot(playerDamageSound);
    }

    public void PlayCoinPickup()
    {
        if (coinPickup != null)
            audioSource.PlayOneShot(coinPickup);
    }

    public void PlayGameOverSound()
    {
        if (gameOverSound != null)
            audioSource.PlayOneShot(gameOverSound);
    }

    public void PlayWinningSound()
    {
        if (winningSound != null)
            audioSource.PlayOneShot(winningSound);
    }

    public void StopBackgroundMusic()
    {
        if (backgroundSound != null)
            backgroundSound.Stop();
    }
}