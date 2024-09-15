using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPauseScript : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanel;
    private bool openPanel;

    // Start is called before the first frame update
    void Start()
    {
        tutorialPanel.SetActive(false);
    }

    private void TogglePanel()
    {
        openPanel = !openPanel;

        if (openPanel)
        {
            tutorialPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            tutorialPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
