using StarterAssets;
using UnityEngine;

public class MainSceneBtnManager : MonoBehaviour
{
    public StarterAssetsInputs starterAssets;
    public FirstPersonController firstPersonController;

    [Header("Pause")]
    public GameObject pausePanel;
    public GameObject menuPanel;
    public GameObject optionsPanel;

    public GameObject currentPanel = null;

    private void Update()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Instance.isGamePaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        AudioManager.Instance.PlaySFX(7);
        pausePanel.SetActive(false);
        currentPanel = null;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;

        firstPersonController.isGamePaused = false;

        GameManager.Instance.isGamePaused = false;
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        currentPanel = menuPanel;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;

        firstPersonController.isGamePaused = true;

        GameManager.Instance.isGamePaused = true;
    }

    public void Options()
    {
        AudioManager.Instance.PlaySFX(7);
        currentPanel.SetActive(false);
        optionsPanel.SetActive(true);
        currentPanel = optionsPanel;
    }

    public void Close()
    {
        AudioManager.Instance.PlaySFX(7);
        currentPanel.SetActive(false);
        currentPanel = menuPanel;
        currentPanel.SetActive(true);
    }

    public void Exit()
    {
        AudioManager.Instance.PlaySFX(7);
        Debug.Log("You closed the game.");
        Application.Quit();
    }
}
