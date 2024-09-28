using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimbing : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Rigidbody rb;
    public LayerMask ladder;

    [Header("Audio")]
    [SerializeField] private AudioSource climbingAudio;
    [SerializeField] private AudioSource fallingAudio;

    [Header("Climbing")]
    public float climbSpeed;
    public float maxClimbTime;
    private float climbTimer;

    private bool climbing;

    [Header("Detection")]
    public float detectionLength;
    public float sphereCastRadius;
    private float wallLookAngle;
    public float maxWallLookAngle;

    private RaycastHit frontWallHit;
    private bool wallInFront;

    private void Statemachine()
    {
        //State 1 - Climbing
        if(wallInFront && Input.GetKey(KeyCode.W) && wallLookAngle < maxWallLookAngle)
        {
            StartClimbing();
        }
        else
        {
            StopClimbing();
        }
    }

    private void Update()
    {
        WallCheck();
        Statemachine();

        if (climbing) ClimbingMovement();

        if(!climbing && SAVED_PlayerMovement.pmInstance.grounded == false)
        {
            fallingAudio.enabled = true;
        }
        else
        {
            fallingAudio.enabled = false;
        }
    }

    private void WallCheck()
    {
        wallInFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out frontWallHit, detectionLength, ladder);
        wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);
    }

    private void StartClimbing()
    {
        climbing = true;
        climbingAudio.enabled = true;
    }

    private void ClimbingMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);
    }

    private void StopClimbing()
    {
        climbing = false;
        climbingAudio.enabled = false;
    }
}
