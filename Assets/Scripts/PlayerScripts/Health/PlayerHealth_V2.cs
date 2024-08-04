using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerHealth_V2 : MonoBehaviour
{
    [SerializeField] private EndGameScript endGame;

    //make list of image vraibales to change ove the course of player damage;
    [Header("Health Visuals")]
    public float intensity = 0;

    PostProcessVolume visualVolume;

    // mech dmg check talks to player dmg check

    public CheckForDamage dmgCheck;

    [Header("Player Health")]
    public float playerHealth = 1f;
    private float playerMaxhealth = 1f;

    //bool to call if player health is empty
    public bool playerHasDied = false;

    public

    // Start is called before the first frame update
    void Start()
    {

        //making sure the game kows this isn't true yet
        playerHasDied = false;

        playerHealth = playerMaxhealth;

        visualVolume = GetComponent<PostProcessVolume>();
        visualVolume.weight = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerFireDamage();

        //PlayerAcidDamage();


        if (playerHealth > 0 && dmgCheck.playerInFire == true || playerHealth > 0 && dmgCheck.playerInAcid == true)
        {

            playerHealth -= 0.001f;

            visualVolume.weight += 0.001f;

            if (visualVolume.weight < 0) visualVolume.weight = 0;

        }

        //player health regeneration
        else if (playerHealth >= 0 && dmgCheck.playerInFire == false)
        {
            playerHealth += 0.0015f;

            visualVolume.weight -= 0.0015f;

            if (visualVolume.weight < 0) visualVolume.weight = 0;

        }

        ////Damage player if they have health above zero and inside acid collider
        //if (playerHealth > 0 && dmgCheck.playerInAcid == true)
        //{
        //    playerHealth -= 0.001f;

        //    visualVolume.weight += 0.01f;

        //   if (visualVolume.weight < 0) visualVolume.weight = 0;
        //}

        ////Player Health regeneration
        //if (playerHealth >= 0 && dmgCheck.playerInAcid == false)
        //{
        //    playerHealth += 0.0015f;

        //    visualVolume.weight -= 0.0015f;

        //    if (visualVolume.weight < 0) visualVolume.weight = 0;
        //}


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

    }


}
