using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SAVED_PlayerMovement : MonoBehaviour
{
    [SerializeField] private EndGameScript endGame;
    [SerializeField] private AudioSource playerFootsteps;
    [SerializeField] private Animator playerAnimator;

    public static SAVED_PlayerMovement pmInstance;

    [Header("Movement")]
    public float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    public float deadSpeed = 0f;

    public float groundDrag;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplyer;
    bool readyToJump;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ground;
    public bool grounded;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    public Transform orientation;
    public bool playerActive;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;

    public bool playerCannotMove = false;

    //public UnityEvent playerPauseGame;

    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air,
        dead,
    }

    private void Start()
    {

        playerCannotMove = false;

        pmInstance = this;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        playerActive = true;

        readyToJump = true;

        startYScale = transform.localScale.y;
    }

    public void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);

        MyInput();
        SpeedControl();
        StateHandler();

        //handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;


        if (!playerCannotMove && endGame.deathAnim == true)
        {
            Debug.Log("playerdie in movement script");
            playerCannotMove = true;
        }

        ////PAUSE GAME
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    //GameManager.current.Pausegame();
        //    playerPauseGame.Invoke();
        //}

    }

    private void SpeedControl()
    {
        //limiting speed on slopes
        if (OnSlope() && !exitingSlope)
        {
            if (rb.velocity.magnitude > moveSpeed)
                rb.velocity = rb.velocity.normalized * moveSpeed;
        }

        //limiting speed on ground or in air
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            //limit velocity if needed
            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);

            }
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        if (GameManager.current.gamePaused) return;

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


        //play walking noises when input for movement keys
        if((horizontalInput > 0 || horizontalInput < 0 || verticalInput > 0f || verticalInput < 0f) && grounded && !endGame.deathAnim)
        {
            playerFootsteps.enabled = true;
            playerAnimator.SetBool("Walking", true);
        }
        else
        {
            playerFootsteps.enabled = false;
            playerAnimator.SetBool("Walking", false);
        }

        //Set Camera Animator bools for leaning
        if (Input.GetKey(KeyCode.A))
        {
            playerAnimator.SetBool("LeanLeft", true);
        }
        else
        {
            playerAnimator.SetBool("LeanLeft", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerAnimator.SetBool("LeanRight", true);
        }

        else
        {
            playerAnimator.SetBool("LeanRight", false);
        }


        //when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        //start crouch
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        //stop crouch
        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }

    private void StateHandler()
    {
        //player death - no movement
        if (playerCannotMove == true)
        {
            state = MovementState.dead;
            moveSpeed = deadSpeed;
        }

        //mode - crouching
        else if (Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
        }

        //mode - spritning
        else if(grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }

        //mode - walking
        else if(grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }

        //mode - air
        else
        {
            state = MovementState.air;
        }
    }

    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on slope
        if (OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }

        // on ground
        else if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplyer, ForceMode.Force);

        // turn gravity off qwhile on slope
        rb.useGravity = !OnSlope();

    }

    private void Jump()
    {
        exitingSlope = true;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;

        exitingSlope = false;
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    //stop jumping when in acid
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Acid")
        {
            //play enter acid sound
            readyToJump = false;
        }
    }

    // let player jump when out of acid
    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Acid")
        {
            //play exit acid sound
            readyToJump = true;
        }
    }



}
