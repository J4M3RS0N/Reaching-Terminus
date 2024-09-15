using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SwayAndBob : MonoBehaviour
{
    Animator mechFrameAnimator;

    [SerializeField] private EnterMechDemo mechEmbarked;
    [SerializeField] private V3_LineLauncher ll;

    private void Start()
    {
        mechFrameAnimator = GetComponent<Animator>();
        ll = FindObjectOfType<V3_LineLauncher>();
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
            if (Input.GetAxisRaw("Horizontal") != 0 && mechEmbarked.playerInMech == true)
            {
                mechFrameAnimator.SetBool("NoFuel", true);
                StartCoroutine(EmptyFuelAnimCycle());
            }

            if (Input.GetAxisRaw("Vertical") != 0 && mechEmbarked.playerInMech == true)
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
        //if the mech isnt zipping then mech bob
        //if (ll.isZipping) return;
        

        if (Input.GetAxisRaw("Horizontal") != 0 && mechEmbarked.playerInMech == true)
        {
            mechFrameAnimator.SetBool("MechWalking", true);

            //if (ll.isZipping == true)
            //{
            //    mechFrameAnimator.SetBool("Zipping", true);
            //}

            //if (ll.isZipping == false)
            //{
            //    mechFrameAnimator.SetBool("Zipping", false);
            //}
        }

        if (Input.GetAxisRaw("Vertical") != 0 && mechEmbarked.playerInMech == true)
        {
            mechFrameAnimator.SetBool("MechWalking", true);

            //if (ll.isZipping == true)
            //{
            //    mechFrameAnimator.SetBool("Zipping", true);
            //}

            //if (ll.isZipping == false)
            //{
            //    mechFrameAnimator.SetBool("Zipping", false);
            //}
        }


        else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 || ToastCollector.instance.currentHealth == 0 || ll.isZipping == true)
        {
            mechFrameAnimator.SetBool("MechWalking", false);

            //if (ll.isZipping == true)
            //{
            //    mechFrameAnimator.SetBool("Zipping", true);
            //}

            //if (ll.isZipping == false)
            //{
            //    mechFrameAnimator.SetBool("Zipping", false);
            //}
        }

    }

    private IEnumerator EmptyFuelAnimCycle()
    {
        yield return new WaitForSeconds(1);

        mechFrameAnimator.SetBool("NoFuelIdle", true);
        
    }
}
