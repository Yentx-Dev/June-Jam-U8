using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] private CinemachineCamera fixedCamera;
    [SerializeField] private CinemachineCamera playerCamera;

    [SerializeField] private PlayerInput playerInput;
    private InputAction pauseAction;

    public GameObject mainMenuScreen;
    public GameObject pauseScreen;
    public GameObject winScreen;
    public GameObject loseScreen;

    public AudioSource audioSource;

    void Start()
    {
        fixedCamera.Priority = 20;
        playerCamera.Priority = 10;

        pauseAction = playerInput.actions["Pause"];
    }

    // Pause game
    void Update()
    {
        if (pauseAction.triggered && gameManager.gameStart == true)
        {
            Time.timeScale = 0f;
            audioSource.Pause();
            pauseScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Switches from fixed camera to player camera
    public void SwitchPlayerCam()
    {
        fixedCamera.Priority = 5;
        playerCamera.Priority = 15;
        mainMenuScreen.SetActive(false);
        gameManager.StartGame();
    }

    // Continue game
    public void ContinueGame()
    {
        Time.timeScale = 1f;
        audioSource.UnPause();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseScreen.SetActive(false);
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        winScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoseGame()
    {
        Time.timeScale = 0f;
        loseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
