using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void Start()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReplayGame()
    {
        GameManager.current.timersPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        animator.SetTrigger("FadeToBlack");

        Debug.Log("Quit");
        Application.Quit();
    }
}
