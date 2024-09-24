using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    [SerializeField] GameObject optionsPanel;
    public GameObject losePanel;
    public TutorialPanelScript llPanel;
    public bool gamePaused;
    public bool linelaunchOpen;

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

        llPanel = GetComponent<TutorialPanelScript>();
     
        //check if the player has a highscore and set the highscore test to that
        //else, no highscore yet
    }

    public void Update()
    {
        // Timer - keep track of duration of current run
        // player score - resources consumed along the trip

        // best time and best score - set best to the current if its higher/ shorter in value

        // set the test for the timer

        //PAUSE GAME
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //GameManager.current.Pausegame();
            Pausegame();
        }
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
            //OptionsScript.currentOP.gameObject.SetActive(true);

            Debug.Log("Pause Game");
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            optionsPanel.SetActive(false);
            //OptionsScript.currentOP.gameObject.SetActive(false);

            Time.timeScale = 1;
        }
    }

    public void WinGame()
    {
        SceneManager.LoadScene("Win Scene");
        Debug.Log("he won");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Player Restarted Run");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
