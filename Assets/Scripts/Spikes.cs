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
            // Disables movement after colliding w obstacle
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.PlayerDie();
            playerController.enabled = false;

            Invoke(nameof(Die), 2f);

            if (hasPlayed) return;
            hasPlayed = true;
            audioSource.PlayOneShot(ripSFX);
        }
    }

    void Die()
    {
        audioSource.PlayOneShot(loseSFX);
        uiManager.LoseGame();
    }
}
