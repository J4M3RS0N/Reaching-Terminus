using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
