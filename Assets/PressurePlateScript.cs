using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mech")
        {
            Debug.Log("On Platform");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mech")
        {
            Debug.Log("Left Platform");
        }
    }
}
   
