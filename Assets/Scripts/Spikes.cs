using UnityEngine;

public class Spikes : MonoBehaviour
{
    public UIManager uiManager;

    public AudioSource audioSource;
    [SerializeField] private AudioClip ripSFX;
    [SerializeField] private AudioClip loseSFX;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(ripSFX);

            // Disables movement after colliding w obstacle
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.PlayerStop();
            playerController.enabled = false;

            Invoke(nameof(Die), 2f);

            if (hasPlayed) return;
            hasPlayed = true;
        }
    }

    void Die()
    {
        audioSource.PlayOneShot(loseSFX, 1f);
        uiManager.LoseGame();
    }
}
