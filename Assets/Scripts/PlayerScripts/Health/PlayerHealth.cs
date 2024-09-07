using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
//using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private EndGameScript endGame;

    //make list of image vraibales to change ove the course of player damage;
    [Header("Health Visuals")]
    public float intensity = 0;

    //PostProcessVolume visualVolume;
    //Vignette visualVignette;

    [SerializeField] public Volume volume;
    Vignette volVignette;

    // mech dmg check talks to player dmg check

    public CheckForDamage dmgCheck;

    [Header("Player Health")]
    public float playerHealth = 1f;
    private float playerMaxhealth = 1f;

    //bool to call if player health is empty
    public bool playerHasDied = false;

    [Header("Audio")]
    private AudioSource phAudio;
    [SerializeField] private AudioClip deathSound;


    // Start is called before the first frame update
    void Start()
    {
        phAudio = GetComponent<AudioSource>();

        //making sure the game kows this isn't true yet
        playerHasDied = false;

        playerHealth = playerMaxhealth;

        //visualVolume = GetComponent<PostProcessVolume>();
        //visualVolume.profile.TryGetSettings<Vignette>(out visualVignette);

        volume.profile.TryGet<Vignette>(out volVignette); 


        //if (!volVignette)
        //{
        //    print("error, vignette error");
        //}

        //else
        //{
        //    volVignette.enabled.Override(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {

        if (playerHealth > 0 && dmgCheck.playerInFire == true || playerHealth > 0 && dmgCheck.playerInAcid == true)
        {
            //DamagePlayerHealth();

            //deplete player health
            playerHealth -= 0.002f;

            //increase vignette intensity
            //volVignette.enabled.Override(true);

            intensity += 0.002f;

            if (intensity < 0) intensity = 0;

            volVignette.intensity.Override(intensity);

        }

        //player health regeneration
        else if (playerHealth >= 0 && dmgCheck.playerInFire == false)
        {
            //RegenPlayerHealth();

            //regen player health
            playerHealth += 0.0015f;

            //reduce vignette intensity
            intensity -= 0.0015f;

            if (intensity < 0) intensity = 0;

            volVignette.intensity.Override(intensity);

        }


        // when health reaches 100 or more, is set to max health
        if (playerHealth > playerMaxhealth)
        {
            playerHealth = playerMaxhealth;
        }

        if (!playerHasDied && playerHealth <= 0)
        {
            PlayerHealthEmpty();
            playerHasDied = true;
        }

    }

    public void PlayerHealthEmpty()
    {
        Debug.Log("player died here");
        endGame.PlayerDied();

        phAudio.PlayOneShot(deathSound);
 
    }



    //Damage player if they have health above zero and inside fire collider
    //if (playerHealth > 0 && dmgCheck.playerInFire == true)
    //{
    //    deplete player health
    //    playerHealth -= 0.001f;

    //    increase vignette intensity
    //    visualVignette.enabled.Override(true);

    //    intensity += 0.001f;

    //    if (intensity < 0) intensity = 0;

    //    visualVignette.intensity.Override(intensity);

    //}

    //Player Health regeneration
    //if (playerHealth >= 0 && dmgCheck.playerInFire == false)
    //{
    //    regen player health
    //    playerHealth += 0.0015f;

    //    reduce vignette intensity
    //    intensity -= 0.0015f;

    //    if (intensity < 0) intensity = 0;

    //    visualVignette.intensity.Override(intensity);
    //    visualVignette.enabled.Override(false);

    //}
}
