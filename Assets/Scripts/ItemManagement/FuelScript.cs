using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuelScript : MonoBehaviour
{
    [Header("Fuel Floats")]
    public float startFuel;
    public float maxFuel = 100f;
    public float fuelConsumptionRate;
    public Slider fuelIndicatorSlid;
    public GameObject noFuelObj;

    private void Start()
    {
        if(startFuel > maxFuel)
        {
            startFuel = maxFuel;
        }

        fuelIndicatorSlid.maxValue = maxFuel;
        UpdateUI();
    }

    public void ReduceFuel()
    {
        //Reduce fuel amount and update slider
        startFuel = Time.deltaTime * fuelConsumptionRate;
        UpdateUI();
    }

    void UpdateUI()
    {
        fuelIndicatorSlid.value = startFuel;

        if(startFuel <= 0 )
        {
            startFuel = 0;
            noFuelObj.SetActive(true);
        }
    }
}
