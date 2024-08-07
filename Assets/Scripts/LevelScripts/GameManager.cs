using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    [SerializeField] GameObject optionsPanel;
    public bool gamePaused;

    private void Awake()
    {
        //gamePaused = false;
    }

    // Start is called before the first frame update
    void Start()
    {

        if (current == null)
        {
            DontDestroyOnLoad(gameObject);
            current = this;
        }
        else
        {
            Destroy(gameObject);
        }
     
        //check if the player has a highscore and set the highscore test to that
        //else, no highscore yet
    }

    public void Update()
    {
        // Timer - keep track of duration of current run
        // player score - resources consumed along the trip

        // best time and best score - set best to the current if its higher/ shorter in value

        // set the test for the timer
    }

    public void Pausegame()
    {
        gamePaused = !gamePaused;

        if (gamePaused)
        {
            Time.timeScale = 0;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            optionsPanel.SetActive(true);

            Debug.Log("Pause Game");
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            optionsPanel.SetActive(false);

            Time.timeScale = 1;
        }


    }

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
}
