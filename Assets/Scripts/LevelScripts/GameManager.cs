using System.Collections;
using System.Collections.Generic;
using TMPro;

//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    [Header("UI")]
    [SerializeField] GameObject optionsPanel;
    public GameObject losePanel;
    public GameObject winPanel;
    public GameObject blackScreen;
    public GameObject skullObj;
    public TutorialPanelScript llPanel;

    [Header("Bools (+")]
    public bool gamePaused;
    public bool linelaunchOpen;
    public bool freezeGame;
    public bool mechTutorialActive;

    [Header("Timer")]
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI finishedRunText;
    [SerializeField] TextMeshProUGUI fastestRunText;
    public GameObject timersPanel;
    public float elapsedTime;
    float runTime;
    float bestTime;

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
        //UpdateBestTimeText(); //because default run time is set to zero,nothing can be lowerthan it so the code cant work properly for best time

        bestTime = PlayerPrefs.GetFloat("BestTimeCurrent", 36000);

        TimeSpan time = TimeSpan.FromSeconds(bestTime);

        fastestRunText.text = time.ToString(@"hh\:mm\:ss");

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        //fastestRunText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //fastestRunText.text = bestTime.ToString("00:00");
        //else, no highscore yet
    }

    public void Update()
    {
        // Timer - keep track of duration of current run
        // player score - resources consumed along the trip

        // best time and best score - set best to the current if its higher/ shorter in value

        // set the test for the timer

        //TIMER
        elapsedTime += Time.deltaTime;
        int hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        //timerText.text = elapsedTime.ToString(); 

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

        if (SAVED_PlayerMovement.pmInstance.playerCannotMove == true) return;

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

    public void FreezeGame()
    {
        freezeGame = !freezeGame;

        if (freezeGame)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void SetRunEndTime()
    {
        runTime = elapsedTime;
        //finishedRunText.text = timerText.text;
        finishedRunText.text = elapsedTime.ToString();

        int hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        finishedRunText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    void CheckBestTime()
    {
        if (runTime < PlayerPrefs.GetFloat("BestTimeCurrent", 36000))
        {
            bestTime = runTime;
            //fastestRunText.text = runTime.ToString();

            PlayerPrefs.SetFloat("BestTimeCurrent", runTime);
            //fastestRunText.text = finishedRunText.text;
            int hours = Mathf.FloorToInt(elapsedTime / 3600);
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            //fastestRunText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
            UpdateBestTimeText();
        }
    }

    void UpdateBestTimeText()
    {
        //fastestRunText.text = $"BestTimeCurrent: {PlayerPrefs.GetFloat("BestTimeCurrent")}";
        bestTime = PlayerPrefs.GetFloat("BestTimeCurrent", 36000);
        fastestRunText.text = bestTime.ToString();

        int hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        fastestRunText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        //Debug.Log("New BestTime");
    }

    public void WinGame()
    {
        SetRunEndTime();
        CheckBestTime();
        timersPanel.SetActive(true);

        //SceneManager.LoadScene("Win Scene");
        Debug.Log("he won");
    }

    public void LoseGame()
    {
        SetRunEndTime();
        //UpdateBestTimeText();
        timersPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        elapsedTime = 0f;
        Pausegame();
        Debug.Log("Player Restarted Run");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
        //SceneManager.LoadScene("Main Menu");
    }
}
