using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_CheckForDamage : MonoBehaviour
{
    public CheckForDamage dmgCheck;
    public EnterMechDemo enterMech;

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Fire" && enterMech.playerInMech == true)
        {
            dmgCheck.playerInFire = true;
        }

        if (col.gameObject.tag == "Geyser" && enterMech.playerInMech == true)
        {
            dmgCheck.playerInGeyser = true;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Fire" && enterMech.playerInMech == true || enterMech.playerInMech == false)
        {
            dmgCheck.playerInFire = false;
        }

        if (col.gameObject.tag == "Geyser" && enterMech.playerInMech == true || enterMech.playerInMech == false)
        {
            dmgCheck.playerInGeyser = false;
        }
    }
}
