using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserDisableScript : MonoBehaviour
{

    private void OnDisable()
    {
        CheckForDamage.dmgCheckInstance.playerInFire = false;
    }
}
