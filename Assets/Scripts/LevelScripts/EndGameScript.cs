using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHPS;

    [SerializeField] GameObject LosePanel;
    //[SerializeField] GameObject mechLosePanel;

    public bool deathAnim;
    public bool gameOver;

    public void Awake()
    {
        deathAnim = false;
        gameOver = false;

    }

    // Start is called before the first frame update
    void Start()
    {
        playerHPS = GetComponent<PlayerHealth>();
    }

    public void Update()
    {
        // if the gameover bool is true, unlock the mouse and allow for button inputs to restart or quit, or return to mainmenu

        if (gameOver)
        {
            //LosePanel.SetActive(true);

            if (Input.GetKey(KeyCode.R))
            {
                LosePanel.SetActive(false);

                SceneManager.LoadScene(1);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                LosePanel.SetActive(false);

                SceneManager.LoadScene("Main Menu");
            }
        }
    }

    public void PlayerDied()
    {
        Debug.Log("Player should be dead");

        // play animation where camera moves / stop player from moving their body or camera
        deathAnim = true;
        StartCoroutine(DeathAnimation());

    }

    //public void Pausegame()
    //{
    //    // SceneManager.LoadScene("Win Scene");
    //    Debug.Log("Pause Game");
    //}

    public void WinGame()
    {
        SceneManager.LoadScene("Win Scene");
        Debug.Log("he won");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    private IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(2);

        GameOver();
    }

    public void GameOver()
    { 
        gameOver = true;
    }
}
