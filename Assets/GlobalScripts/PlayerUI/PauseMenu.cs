
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    bool isPaused = false;

    PlayerInputActions playerUIControls;
    InputAction escapeButton;

    private void Awake()
    {
        PausePanel.SetActive(false);

        playerUIControls = new PlayerInputActions();
        escapeButton = playerUIControls.UI.Cancel;
    }

    private void OnEnable()
    {
        playerUIControls.Enable();
        escapeButton.Enable();
    }

    private void OnDisable()
    {
        playerUIControls.Disable();
        escapeButton.Disable();
    }

    private void Update()
    {
        if (escapeButton.triggered)
        {
            isPaused = !isPaused;
        }

        PauseGame();
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Quit2MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
