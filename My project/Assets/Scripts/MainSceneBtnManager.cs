using StarterAssets;
using UnityEngine;

public class MainSceneBtnManager : MonoBehaviour
{
    public StarterAssetsInputs starterAssets;
    public FirstPersonController firstPersonController;

    [Header("Pause")]
    public GameObject pausePanel;

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
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;

        firstPersonController.isGamePaused = false;

        GameManager.Instance.isGamePaused = false;
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;

        firstPersonController.isGamePaused = true;

        GameManager.Instance.isGamePaused = true;
    }

    public void Exit()
    {
        Debug.Log("You closed the game.");
        Application.Quit();
    }
}
