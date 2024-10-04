using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkPlayerScript : MonoBehaviour
{
    public Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Tar")
        {
            rb.isKinematic = true;
            //rb.useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tar")
        {
            rb.isKinematic = false;
            //rb.useGravity = false;
        }
    }
}
