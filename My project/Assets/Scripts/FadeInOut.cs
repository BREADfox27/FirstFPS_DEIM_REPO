using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] float transitiontime = 1f;
    public Animator transitionAnimator;
    
    void Start()
    {
        transitionAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(SceneLoad(nextSceneIndex));
    }

    public void CloseGame()
    {
        Time.timeScale = 1;
        StartCoroutine(ExitGame());
    }

    public IEnumerator SceneLoad(int sceneIndex)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(sceneIndex);
    }
    public IEnumerator ExitGame()
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitiontime);
        Application.Quit();
    }
}
