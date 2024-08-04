using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMech : MonoBehaviour
{
    public static RotateMech instance;

    [Header("Rotation")]
    private float rotation;
    //public float rotateSpeed = 30f;

    float horizontalInput;

    public float sensX;
    public float sensY;

    public Transform mechOrientation;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    private void MyInput()
    {
        //horizontalInput = Input.GetAxisRaw("Horizontal");

    }

    // Update is called once per frame
    void Update()
    {
        if (!MechMovement.instance.mechCannotMove)
        {
            //if (MechMovement.instance.mechActive)
            //{
            //    MyInput();
            //    MechRotate();
            //}

            if (MechMovement.instance.mechActive)
            {
                //rotation = horizontalInput * rotateSpeed * Time.deltaTime;

                float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
                float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

                yRotation += mouseX;

                xRotation -= mouseY;
                //xRotation = Mathf.Clamp(xRotation, -40f, 25f);

                transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
                mechOrientation.rotation = Quaternion.Euler(0, yRotation, 0);

            }


        }
        else
        {
            MechMovement.instance.mechActive = false;
        }
        
    }

    public void MechRotate()
    {
        if (MechMovement.instance.mechActive)
        {
            //rotation = horizontalInput * rotateSpeed * Time.deltaTime;

        }
    }

    private void LateUpdate()
    {
        if (ToastCollector.instance.currentHealth <= 0)
        {
            return;
        }
        transform.Rotate(0f, rotation, 0f);
    }
}
