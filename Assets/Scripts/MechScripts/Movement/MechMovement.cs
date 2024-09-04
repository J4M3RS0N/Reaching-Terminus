using System.Collections;
using System.Collections.Generic;
//using UnityEditor.TextCore.Text;
using UnityEngine;

public class MechMovement : MonoBehaviour
{
    [SerializeField] private EndGameScript endGame;
    [SerializeField] public EnterMechDemo enterMechDemo;

    public static MechMovement instance;

    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;

    public float deadSpeed = 0f;

    public float groundDrag;

    [Header("Mech movement stuff")]
    //rotate mech body float
    public float mechRotationSpeed;

    public float airMultiplyer;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ground;

    public float groundRadius;
    public float gCastDistance;
    RaycastHit groundHit;

    public bool grounded;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    public Transform mechOrientation;
    public GameObject mechObj;

    private float horizontalInput;
    private float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public bool mechActive;

    public MovementState state;

    public bool mechCannotMove = false;

    public enum MovementState
    {
        walking,
        air,
        dead
    }


    // Start is called before the first frame update
    void Start()
    {
        mechCannotMove = false;

        instance = this;

        mechActive = false;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        //If player is in the Mech allow movement
        if (CoolantCollector.instance.coolantRunning)
        {
            if (mechActive == true)
            {
                MoveMech();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ground check
        grounded = Physics.CheckSphere(transform.position - new Vector3(0, 2.85f, 0), groundRadius, ground);

        //If players have entered the Mech
        if (CoolantCollector.instance.coolantRunning)
        {
            if (mechActive == true)
            {
                MyInput();
                StateHandler();
                SpeedControl();
            }
        }

        if (mechActive == true)
        {
            // new event system input to exit the mech
            DisembarkMech();
        }

        //handle drag
        if (grounded)
            rb.drag = groundDrag;

        else
            rb.drag = 0;


        if (!mechCannotMove && endGame.deathAnim == true)
        {
            Debug.Log("playerdie in movement script");
            mechCannotMove = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //GameManager.current.Pausegame();
            
        }
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

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }


    private void StateHandler()
    {
        //player death - no movement
        if (mechCannotMove == true)
        {
            state = MovementState.dead;
            moveSpeed = deadSpeed;
            Debug.Log(state = MovementState.dead);
        }

        //mode - walking
        else if (grounded)
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


    private void MoveMech()
    {

        if (ToastCollector.instance.currentHealth <= 0)
        {
            rb.isKinematic = true;
            rb.angularVelocity = Vector3.zero;

            return;
        }
        else
        {
            rb.isKinematic = false;
        }

        //moveDirection = mechObj.transform.forward * verticalInput + mechObj.transform.right * horizontalInput;
        moveDirection = mechOrientation.forward * verticalInput + mechOrientation.right * horizontalInput;

        //// Rotates the mech object acording to the mechs movedirection
        //if (moveDirection != Vector3.zero)
        //{
        //    Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, mechRotationSpeed * Time.deltaTime);
        //}


        if (OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }


        // on ground
        else if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplyer, ForceMode.Force);

        // turn gravity off while on slope
        rb.useGravity = !OnSlope();
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.5f))
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

    public void DisembarkMech()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            enterMechDemo.ToggleEmbark();
        }
    }
}
