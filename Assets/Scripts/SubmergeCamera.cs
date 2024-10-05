using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SubmergeCamera : MonoBehaviour
{
    [SerializeField] private Volume volumeVFX;
    [SerializeField] private VolumeProfile originalVolProfile;
    [SerializeField] private VolumeProfile acidVolProfile;
    [SerializeField] private VolumeProfile tarVolProfile;

    public bool camIsUnderwater;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Acid")
        {
            //Debug.Log("OnTriggerEnter called with: " + other.tag);
            camIsUnderwater = true;
            volumeVFX.profile = acidVolProfile;
        }

        if (other.gameObject.tag == "Tar")
        {
            camIsUnderwater = true;
            volumeVFX.profile = tarVolProfile;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Acid") 
        {
            camIsUnderwater = false;
            volumeVFX.profile = originalVolProfile;
        }

        if(other.gameObject.tag == "Tar")
        {
            volumeVFX.profile = originalVolProfile;
        }
    }
}
