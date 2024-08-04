using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCamMove : MonoBehaviour
{
    [SerializeField] private EndGameScript endGame;

    Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (endGame.deathAnim == true)
        {
            playerAnimator.SetBool("PlayerDead", true);
        }
    }
}
