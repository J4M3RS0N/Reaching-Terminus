using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CheckForDamage : MonoBehaviour
{
    public static CheckForDamage dmgCheckInstance;

    public AudioSource fireDmgAudio;
    public AudioSource acidDmgAudio;
    public AudioSource geyserDmgAudio;
    public AudioSource tarDmgAudio;

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
            fireDmgAudio.enabled = true;
        }

        if (col.gameObject.tag == "Acid")
        {
            playerInAcid = true;
            acidDmgAudio.enabled = true;
        }

        if (col.gameObject.tag == "Geyser")
        {
            playerInGeyser = true;
            geyserDmgAudio.enabled = true;
        }

        if (col.gameObject.tag == "Tar")
        {
            playerInTar = true;
            tarDmgAudio.enabled = true;
        }
    }

    //when they leave a damaging collider, tell the health script
    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Fire")
        {
            playerInFire = false;
            fireDmgAudio.enabled = false;
        }

        if (col.gameObject.tag == "Acid")
        {
            playerInAcid = false;
            acidDmgAudio.enabled = false;
        }

        if (col.gameObject.tag == "Geyser")
        {
            playerInGeyser = false;
            geyserDmgAudio.enabled = false;
        }

        if (col.gameObject.tag == "Tar")
        {
            playerInTar = false;
            tarDmgAudio.enabled = false;
        }
    }
}
