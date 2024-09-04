using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SwayAndBob : MonoBehaviour
{
    Animator mechFrameAnimator;
    [SerializeField] private AudioSource mechFootstepAudio;

    private void Start()
    {
        mechFrameAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (MechMovement.instance.mechCannotMove == true)
        {
            mechFrameAnimator.SetBool("PlayerDead", true);
        }

        if (ToastCollector.instance.currentHealth <= 0 || CoolantCollector.instance.coolantRunning == false)
        {
            //mechFrameAnimator.enabled = false;
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                mechFrameAnimator.SetBool("NoFuel", true);
                StartCoroutine(EmptyFuelAnimCycle());

                mechFootstepAudio.enabled = false;
            }

            if (Input.GetAxisRaw("Vertical") != 0)
            {
                mechFrameAnimator.SetBool("NoFuel", true);
                StartCoroutine(EmptyFuelAnimCycle());

            }

            else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                mechFrameAnimator.SetBool("NoFuelIdle", true);
            }

            //mechFrameAnimator.SetBool("NoFuel", true);

            return;
        }
        else
        {
            //mechFrameAnimator.enabled = true;
            mechFrameAnimator.SetBool("NoFuel", false);
            mechFrameAnimator.SetBool("NoFuelIdle", false);
            MechBob();
        }
    }

    private void MechBob()
    {
        if (Input.GetAxisRaw("Horizontal") !=0)
        {
            mechFrameAnimator.SetBool("MechWalking", true);
            mechFootstepAudio.enabled = true;
        }

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            mechFrameAnimator.SetBool("MechWalking", true);
            mechFootstepAudio.enabled = true;
        }

        else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            mechFrameAnimator.SetBool("MechWalking", false);
            mechFootstepAudio.enabled = false;
        }

    }

    private IEnumerator EmptyFuelAnimCycle()
    {
        yield return new WaitForSeconds(1);

        mechFrameAnimator.SetBool("NoFuelIdle", true);
        
    }
}
