using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHPS;

    //[SerializeField] GameObject LosePanel;
    //[SerializeField] GameObject mechLosePanel;
    [Header("Color Fading")]
    public Animator animator;

    public bool deathAnim;
    public bool gameOver;
    public bool victoryMode;

    public void Awake()
    {
        deathAnim = false;
        gameOver = false;
        victoryMode = false;

    }

    // Start is called before the first frame update
    void Start()
    {
        playerHPS = GetComponent<PlayerHealth>();
    }

    public void Update()
    {
        // if the gameover bool is true, unlock the mouse and allow for button inputs to restart or quit, or return to mainmenu

        if (gameOver && deathAnim)
        {
            //LosePanel.SetActive(true);
            GameManager.current.losePanel.SetActive(true);
            GameManager.current.timersPanel.SetActive(true);

            if (Input.GetKey(KeyCode.R))
            {
                //Hide Panels and load scene
                StartCoroutine(RestartGame());
            }
            if (Input.GetKey(KeyCode.Q))
            {
                StartCoroutine(CloseGame());
            }
        }

        if(gameOver && victoryMode)
        {
            GameManager.current.winPanel.SetActive(true);
            GameManager.current.timersPanel.SetActive(true);

            if (Input.GetKey(KeyCode.R))
            {
                //Hide Panels and load scene
                StartCoroutine(RestartGame());
            }
            if (Input.GetKey(KeyCode.Q))
            {
                StartCoroutine(CloseGame());
            }
        }

        else
        {
            GameManager.current.blackScreen.SetActive(false);
        }
    }

    public void PlayerDied()
    {
        Debug.Log("Player should be dead");

        // play animation where camera moves / stop player from moving their body or camera

        deathAnim = true;
        GameManager.current.WinGame();
        StartCoroutine(DeathAnimation());

    }

    public void WinGame()
    {
        //SceneManager.LoadScene("Win Scene");
        victoryMode = true;
        Debug.Log("he won");
    }

    public IEnumerator RestartGame()
    {
        animator.SetTrigger("FadeToBlack");
        yield return new WaitForSeconds(1);

        GameManager.current.blackScreen.SetActive(true);
        GameManager.current.winPanel.SetActive(false);
        GameManager.current.losePanel.SetActive(false);
        GameManager.current.timersPanel.SetActive(false);

        SceneManager.LoadScene(1);
        GameManager.current.elapsedTime = 0f;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    private IEnumerator CloseGame()
    {
        //fade game to black before quitting
        animator.SetTrigger("FadeToBlack");
        yield return new WaitForSeconds(1);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //Hide Panels and load scene
        GameManager.current.winPanel.SetActive(false);

        GameManager.current.losePanel.SetActive(false);
        GameManager.current.timersPanel.SetActive(false);

        QuitGame();
    }

    private IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(2);

        GameOver();
    }

    public void GameOver()
    { 
        gameOver = true;
        GameManager.current.SetRunEndTime();
    }
}
