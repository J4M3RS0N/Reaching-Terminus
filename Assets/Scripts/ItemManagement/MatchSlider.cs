using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchSlider : MonoBehaviour
{
    public Slider newSlider;
    public Slider originalSlider;

    // Update is called once per frame
    void Update()
    {
        //newSlider.value = CoolantCollector.instance.currentHealth;
        newSlider.value = originalSlider.value;
    }
}
