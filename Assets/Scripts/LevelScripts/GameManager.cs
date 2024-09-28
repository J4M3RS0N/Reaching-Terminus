using System.Collections;
using System.Collections.Generic;
using TMPro;

//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    [Header("UI")]
    [SerializeField] GameObject optionsPanel;
    public GameObject losePanel;
    public GameObject blackScreen;
    public TutorialPanelScript llPanel;

    [Header("Bools (+")]
    public bool gamePaused;
    public bool linelaunchOpen;

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

        blackScreen.SetActive(false);

        //check if the player has a highscore and set the highscore test to that
        UpdateBestTimeText();

        bestTime = PlayerPrefs.GetFloat("BestTime", 0);
        fastestRunText.text = bestTime.ToString("00:00");
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
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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

    public void SetRunEndTime()
    {
        runTime = elapsedTime;
        //finishedRunText.text = timerText.text;
        finishedRunText.text = elapsedTime.ToString();

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        finishedRunText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void CheckBestTime()
    {
        if (runTime < PlayerPrefs.GetFloat("BestTime", 0))
        {
            bestTime = runTime;
            //fastestRunText.text = runTime.ToString();

            PlayerPrefs.SetFloat("BestTime", runTime);
            UpdateBestTimeText();
        }
    }

    void UpdateBestTimeText()
    {
        fastestRunText.text = $"BestTime: {PlayerPrefs.GetFloat("BestTime", 0)}";

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        fastestRunText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        Debug.Log("New BestTime");
    }

    public void WinGame()
    {
        SetRunEndTime();
        CheckBestTime();
        timersPanel.SetActive(true);

        //SceneManager.LoadScene("Win Scene");
        Debug.Log("he won");
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
    }
}
