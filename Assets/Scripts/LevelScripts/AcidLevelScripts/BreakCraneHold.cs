using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCraneHold : MonoBehaviour
{
    public CraneScript craneScript;

    private float craneHealth = 10;

    public void CraneTakeDamage(float amount)
    {
        craneHealth -= amount;
        if (craneHealth <= 0f)
        {
            craneScript.DropContainer();
        }
    }
}
