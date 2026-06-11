using UnityEngine;
using UnityEngine.Audio;

public class WinGame : MonoBehaviour
{
    public UIManager uiManager;

    public AudioSource audioSource;
    [SerializeField] private AudioClip winSFX;
    [SerializeField] private AudioClip winGameSFX;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disables movement after colliding w final trash bin
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.enabled = false;

            Invoke(nameof(Win), 2f);

            if (hasPlayed) return;
            hasPlayed = true;
            audioSource.PlayOneShot(winSFX);
        }
    }

    void Win()
    {
        audioSource.PlayOneShot(winGameSFX);
        uiManager.WinGame();
    }
}
