using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCollector : MonoBehaviour
{
    [SerializeField] private GameObject visualBattery;
    [SerializeField] private Animator gateAnimator;
    
    [SerializeField] private AudioSource batteryAudio;
    [SerializeField] private AudioClip collectSound;

    public bool gatePowered;

    // Start is called before the first frame update
    void Start()
    {
        visualBattery.SetActive(false);
        gatePowered = false;
        //intscript = Get
    }

   //if battery is collected, open the gate
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Battery"))
        {
            batteryAudio.PlayOneShot(collectSound);

            gatePowered = true;

            Destroy(other.gameObject);

            New_InteractScript.interactInstance.DropObject();

            visualBattery.SetActive(true);

            gateAnimator.SetBool("OpenGate", true);
        }
        else
        {
            return;
        }
    }
}
