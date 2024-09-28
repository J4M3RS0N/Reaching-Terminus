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
        SceneManager.LoadScene(1);
    }

    public IEnumerator QuitGame()
    {
        animator.SetTrigger("FadeToBlack");
        yield return new WaitForSeconds(1);

        Debug.Log("Quit");
        Application.Quit();
    }
}
