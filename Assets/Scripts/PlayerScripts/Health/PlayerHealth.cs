using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
//using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;

public class PlayerHealth : MonoBehaviour
{
    public List<AudioClip> damageSounds = new List<AudioClip>();

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

    private float fireDamage = 0.002f;
    private float geyserDamage = 0.007f;
    private float acidDamage = 0.004f;
    private float tarDamage = 0.002f;

    //bool to call if player health is empty
    public bool playerHasDied = false;
    public bool takingDamage;

    [Header("Audio")]
    private AudioSource phAudio;
    [SerializeField] private AudioClip deathSound;


    // Start is called before the first frame update
    void Start()
    {
        phAudio = GetComponent<AudioSource>();

        //making sure the game kows this isn't true yet
        playerHasDied = false;
        takingDamage = false;

        playerHealth = playerMaxhealth;

        volume.profile.TryGet<Vignette>(out volVignette); 
    }

    // Update is called once per frame
    void Update()
    {
        //if(takingDamage == true)
        //{
        
        //}
        //if(takingDamage == false)
        //{
        
        //}

        //Damage player accodring to fire bool and fire damage float
        if (playerHealth > 0 && dmgCheck.playerInFire == true)
        {
            //play damage audio
            //takingDamage = true;

            //deplete player health
            playerHealth -= fireDamage;

            intensity += fireDamage;

            if (intensity < 0) intensity = 0;

            volVignette.intensity.Override(intensity);

        }

        //damage player according to acid bool and acid damage float
        if (playerHealth > 0 && dmgCheck.playerInAcid == true)
        {
            //takingDamage = tru

            playerHealth -= acidDamage;

            intensity += acidDamage;

            if (intensity < 0) intensity = 0;

            volVignette.intensity.Override(intensity);
        }

        //damage player according to geyser bool and damage float
        if (playerHealth > 0 && dmgCheck.playerInGeyser == true)
        {
            //takingDamage = true;


            playerHealth -= geyserDamage;

            intensity += geyserDamage;

            if (intensity < 0) intensity = 0;

            volVignette.intensity.Override(intensity);
        }

        //damage player when in tar and stop them from moving
        if (playerHealth > 0 && dmgCheck.playerInTar == true)
        {
            //takingDamage = true


            playerHealth -= tarDamage;

            intensity += tarDamage;

            if (intensity < 0) intensity = 0;

            volVignette.intensity.Override(intensity);
        }

        //player health regeneration
        else if (playerHealth >= 0 && dmgCheck.playerInFire == false)
        {
            //takingDamage = false;

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

        //takingDamage = false;

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
