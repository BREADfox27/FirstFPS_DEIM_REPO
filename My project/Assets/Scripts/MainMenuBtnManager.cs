using UnityEngine;

public class MainMenuBtnManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public FadeInOut fade;

    private void Start()
    {
        fade = FindAnyObjectByType<FadeInOut>();
    }

    public void Play()
    {
        AudioManager.Instance.PlaySFX(7);
        fade.LoadNextScene();
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
        fade.CloseGame();
    }
}
