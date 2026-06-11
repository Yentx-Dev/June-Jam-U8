using Unity.Cinemachine;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] private CinemachineCamera fixedCamera;
    [SerializeField] private CinemachineCamera playerCamera;

    public GameObject pauseScreen;
    public GameObject mainMenuScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fixedCamera.Priority = 20;
        playerCamera.Priority = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchPlayerCam()
    {
        fixedCamera.Priority = 5;
        playerCamera.Priority = 15;
        mainMenuScreen.SetActive(false);
        gameManager.StartGame();
    }

    public void PauseGame()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ContinueGame()
    {
        pauseScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void WinGame()
    {

    }

    public void LoseGame()
    {

    }
}
