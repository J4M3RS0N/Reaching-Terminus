using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguisherToggle : MonoBehaviour
{
    public GameObject fireExtinguisher;
    public GameObject extinguisherAsset;
    public bool equipped;
    // Start is called before the first frame update
    void Start()
    {
        equipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleExtinguisher()
    {
        equipped = !equipped;

        if (equipped)
        {
            fireExtinguisher.SetActive(true);
            extinguisherAsset.SetActive(false);
        }
        else
        {
            fireExtinguisher.SetActive(false);
            extinguisherAsset.SetActive(true);
        }
    }
}
