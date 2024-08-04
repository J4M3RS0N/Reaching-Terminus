using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMechMove : MonoBehaviour
{
    //public static MechMovement instance;

    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;

    public float groundDrag;

    [Header("Mech movement stuff")]
    //private float rotation;
    //public float rotateSpeed = 30f;

    public float airMultiplyer;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ground;
    bool grounded;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    public Transform mechOrientation;
    public GameObject mechObj;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public bool mechActive;

    public MovementState state;
    public enum MovementState
    {
        walking,
        air
    }


    // Start is called before the first frame update
    void Start()
    {
        //instance = this;

        mechActive = false;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    private void FixedUpdate()
    {
        //If player is in the Mech allow movement
        if (mechActive)
        {
            MoveMech();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);

        //If players have entered the Mech
        if (mechActive)
        {
            MyInput();
            StateHandler();
            SpeedControl();
            //FreezeMech();
        }

        //handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
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

        //mode - walking
        if (grounded)
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

        moveDirection = mechObj.transform.forward * verticalInput + mechObj.transform.right * horizontalInput;
        //rotation = horizontalInput * rotateSpeed * Time.deltaTime;
        RotateMech.instance.MechRotate();


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

        // turn gravity off qwhile on slope
        rb.useGravity = !OnSlope();
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

    //private void LateUpdate()
    //{
    /*if (ToastCollector.instance.currentHealth <= 0)
    {
        return;
    }
    transform.Rotate(0f, rotation, 0f);*/
    //}
}
