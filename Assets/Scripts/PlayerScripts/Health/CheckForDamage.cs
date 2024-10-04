using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CheckForDamage : MonoBehaviour
{
    public static CheckForDamage dmgCheckInstance;

    public bool playerInFire;
    public bool playerInAcid;
    public bool playerInGeyser;
    public bool playerInTar;

    public void Start()
    {
        dmgCheckInstance = this;
    }

    //Check if Player is touching a damaging collider
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Fire")
        {
            playerInFire = true;
        }

        if (col.gameObject.tag == "Acid")
        {
            playerInAcid = true;
        }

        if (col.gameObject.tag == "Geyser")
        {
            playerInGeyser = true;
        }

        if (col.gameObject.tag == "Tar")
        {
            playerInTar = true;
        }
    }

    //when they leave a damaging collider, tell the health script
    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Fire")
        {
            playerInFire = false;
            //.Log("player left fire");
        }

        if (col.gameObject.tag == "Acid")
        {
            playerInAcid = false;
        }

        if (col.gameObject.tag == "Geyser")
        {
            playerInGeyser = false;
        }

        if (col.gameObject.tag == "Tar")
        {
            playerInTar = false;
        }
    }
}
