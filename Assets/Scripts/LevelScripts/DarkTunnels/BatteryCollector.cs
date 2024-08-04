using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCollector : MonoBehaviour
{
    [SerializeField] private GameObject visualBattery;
    [SerializeField] private Animator gateAnimator;

    public bool gatePowered;

    // Start is called before the first frame update
    void Start()
    {
        visualBattery.SetActive(false);
        gatePowered = false;
    }

   //if battery is collected, open the gate
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Battery"))
        {
            gatePowered = true;

            Destroy(other.gameObject);

            visualBattery.SetActive(true);

            gateAnimator.SetBool("OpenGate", true);
        }
        else
        {
            return;
        }
    }
}
