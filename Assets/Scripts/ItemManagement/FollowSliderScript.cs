using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowSliderScript : MonoBehaviour
{
    public Slider newSlider;

    private void Update()
    {
        newSlider.value = CoolantCollector.instance.currentHealth;
    }
}
