using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightMech : MonoBehaviour
{
    [SerializeField] private GameObject spotlight;
    public bool setLightStatus;

    // Start is called before the first frame update
    void Start()
    {
        setLightStatus = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (ToastCollector.instance.currentHealth <= 0)
        {
            spotlight.SetActive(false);
        }

        else
        {
            spotlight.SetActive(true);
        }
        
    }
}
