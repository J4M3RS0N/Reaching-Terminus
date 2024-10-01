using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleExtinguisher : MonoBehaviour
{
    public GameObject extingusiherObj;
    public GameObject mechanicExtinguisher;
    public bool extinguisherActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleExtinguisherFunction()
    {
        extinguisherActive = !extinguisherActive;

        if(extinguisherActive)
        {
            mechanicExtinguisher.SetActive(true);
            extingusiherObj.SetActive(false);
            Debug.Log("extin On");
        }
        else
        {
            mechanicExtinguisher.SetActive(false);
            extingusiherObj.SetActive(true);
            Debug.Log("Extin OFF");
        }
    }
}
