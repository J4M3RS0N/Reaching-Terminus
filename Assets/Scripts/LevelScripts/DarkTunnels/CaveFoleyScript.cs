using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveFoleyScript : MonoBehaviour
{
    private AudioSource caveAudio;

    private void Start()
    {
        caveAudio = GetComponent<AudioSource>();
        caveAudio.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            caveAudio.enabled = true;
        }

        if(other.gameObject.tag == "Mech")
        {
            caveAudio.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            caveAudio.enabled = false;
        }
    }

}
