using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtnManager : MonoBehaviour
{
    public GameObject optionsPanel;

    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Options()
    {
        optionsPanel.SetActive(true);
    }

    public void Close()
    {
        optionsPanel.SetActive(false);
    }

    public void Exit()
    {
        Debug.Log("You closed the game.");
        Application.Quit();
    }
}
