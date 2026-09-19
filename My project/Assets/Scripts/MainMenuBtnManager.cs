using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtnManager : MonoBehaviour
{
    public GameObject optionsPanel;

    public void Play()
    {
        AudioManager.Instance.PlaySFX(7);
        SceneManager.LoadScene("MainScene");
    }

    public void Options()
    {
        AudioManager.Instance.PlaySFX(7);
        optionsPanel.SetActive(true);
    }

    public void Close()
    {
        AudioManager.Instance.PlaySFX(7);
        optionsPanel.SetActive(false);
    }

    public void Exit()
    {
        AudioManager.Instance.PlaySFX(7);
        Debug.Log("You closed the game.");
        Application.Quit();
    }
}
