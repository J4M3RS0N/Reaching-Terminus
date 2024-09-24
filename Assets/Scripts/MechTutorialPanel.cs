using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MechTutorialPanel : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanel;
    private bool openMechPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if(openMechPanel == true && Input.GetKeyDown(KeyCode.F))
        {
            openMechPanel = false;
            tutorialPanel.SetActive(false);
            Time.timeScale = 1;

            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LineLauncherPickup")
        {
            //ll.canZip = true;

            openMechPanel = true;
            tutorialPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
