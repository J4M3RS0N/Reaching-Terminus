using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkPlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private GameObject fallingAudio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Tar")
        {
            rb.isKinematic = true;
            fallingAudio.SetActive(false);
            //rb.useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tar")
        {
            rb.isKinematic = false;
            //audioSource.enabled = false;
            //rb.useGravity = false;
        }
    }
}
