using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtnManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Exit()
    {
        Debug.Log("You closed the game.");
        Application.Quit();
    }
}
