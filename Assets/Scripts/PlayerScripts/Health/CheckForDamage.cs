using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CheckForDamage : MonoBehaviour
{
    //public static CheckForDamage phInstance;

    public bool playerInFire;
    public bool playerInAcid;

    public void Start()
    {
        //phInstance = this;
    }

    //Check if Player is touching a damaging collider
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Fire")
        {
            playerInFire = true;
            //debug.log("is inside damage area");
        }

        if (col.gameObject.tag == "Acid")
        {
            playerInAcid = true;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Fire")
        {
            playerInFire = false;
            //debug.log("player left fire");
        }

        if (col.gameObject.tag == "Acid")
        {
            playerInAcid = false;
        }
    }
}
