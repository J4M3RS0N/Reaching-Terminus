using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialPanelScript : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    public string titleText;
    public string descriptionText;

    [Header("Images")]
    [SerializeField] private Image imageA;
    [SerializeField] private Image imageB;
    [SerializeField] private Sprite spriteA;
    [SerializeField] private Sprite spriteB;

    public bool openPanel;

    // Start is called before the first frame update
    void Start()
    {
        title.text = titleText;
        description.text = descriptionText;

        imageA.sprite = spriteA;
        imageB.sprite = spriteB;
    }

    public void TogglePanel()
    {
        openPanel = !openPanel;

        if (openPanel)
        {
            this.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
