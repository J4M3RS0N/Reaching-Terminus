using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI finishedRunText;
    [SerializeField] TextMeshProUGUI fastestRunText;
    float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //timerText.text = elapsedTime.ToString();    
    }

    void CheckBestTime()
    {
        if(elapsedTime > PlayerPrefs.GetFloat("BestTime", 0))
        {
            PlayerPrefs.SetFloat("BestTime", elapsedTime);
        }
    }
}
