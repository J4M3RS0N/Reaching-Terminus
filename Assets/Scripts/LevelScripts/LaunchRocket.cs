using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRocket : MonoBehaviour
{
    [Header("Script References")]
    public EndGameScript endGame;
    public Animator tAnimatior;
    public ShakeCamera tCamShake;

    [Header("Cameras")]
    public GameObject playerCam;
    public GameObject tCam;

    [Header("Audio")]
    public AudioSource cargoAudio;
    public AudioSource rocketAudio;

    [Header("GameObjects")]
    public GameObject doorBlockers;
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
        doorBlockers.SetActive(true);
        tAnimatior.SetTrigger("LoadMechCargo");
        cargoAudio.enabled = true;
        yield return new WaitForSeconds(6.5f);
        launchButton.SetActive(true);
        cargoButton.SetActive(false);

    }

    public IEnumerator ReleaseRocket()
    {
        hideLaunchButtonObj.SetActive(true);
        tAnimatior.SetTrigger("ReleaseRocket");
        rocketAudio.enabled = true;

        yield return new WaitForSeconds(1);
        playerCam.SetActive(false);
        tCam.SetActive(true);
        tCamShake.ShakeTheCamera();

        yield return new WaitForSeconds(1);
        tAnimatior.SetTrigger("FireRocket");

        yield return new WaitForSeconds(3);
        endGame.WinGame();
        //endGame.GameOver();
        endGame.gameOver = true;
        //yield return null;

        //wait a little longer then win game stuff
    }
}
