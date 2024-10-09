using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRocket : MonoBehaviour
{
    //load mech cargo onto rocket by rasing mech up, loading cargo then lowering mech
    //Laucnh the rocket: release side clamps, start firing particle system, shoot rocket up and out into sky/offscreen; endgame/win game

    //Coroutine order:

    //First button press animates mech on platforming being raised to exposed section of rocket
    //wait 2 seconds
    // cargo arm frame reaches outfrom rocket and takes cargo off of mech
    //wait 4 seconds
    //mech is lowered back to the ground

    //LaunchRocket croutine starsts


    // unclamp rocket animation plays, and start up steam PS is turned on
    //wait 2 seconds
    // 3 second countdown timer for launch
    // rocket lift off, activate rocket trail PS and rocket leaving animation
    //wait 5- 10 seconds
    //win game is true (panel opr scene, still undecided)

    public Animator tAnimatior;
    public GameObject cargoButton;
    public GameObject launchButton;
    public GameObject hideLaunchButtonObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartCargoCoroutine()
    {
        StartCoroutine(LoadMechCargo());
    }

    public void StartLaunchSequence()
    {
        StartCoroutine(ReleaseRocket());
    }

    public IEnumerator LoadMechCargo()
    {
        tAnimatior.SetTrigger("LoadMechCargo");
        yield return new WaitForSeconds(6.5f);
        launchButton.SetActive(true);
        cargoButton.SetActive(false);

    }

    public IEnumerator ReleaseRocket()
    {
        hideLaunchButtonObj.SetActive(true);
        tAnimatior.SetTrigger("ReleaseRocket");
        yield return new WaitForSeconds(2);
        tAnimatior.SetTrigger("FireRocket");

        //wait a little longer then win game stuff
    }
}
