using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform mechOrientation;
    public Transform mechBody;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (MechMovement.instance.mechCannotMove == true) return;

        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -40f, 25f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        mechOrientation.rotation = Quaternion.Euler(0, yRotation, 0);

        mechBody.Rotate(Vector3.up * mouseX);
    }
}
