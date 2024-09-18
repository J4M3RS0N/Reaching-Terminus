using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MechCamera : MonoBehaviour
{
    //public float sensX;
    //public float sensY;

    //public Transform mechOrientation;
    //public Transform mechBody;

    //float xRotation;
    //float yRotation;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = false;
    //}

    //private void Update()
    //{
    //    if (MechMovement.instance.mechCannotMove == true) return;

    //    //get mouse input
    //    float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
    //    float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

    //    yRotation += mouseX;

    //    xRotation -= mouseY;
    //    xRotation = Mathf.Clamp(xRotation, -40f, 25f);

    //    transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    //    mechOrientation.rotation = Quaternion.Euler(0, yRotation, 0);

    //    mechBody.Rotate(Vector3.up * mouseX);
    //}

    [SerializeField] private EndGameScript endGame;
    [SerializeField] private Slider slider;

    //public float sensX;
    //public float sensY;

    public float mouseSensitivityM = 100;

    public Transform mechOrientation;
    public Transform mechBody;

    float xRotation;
    float yRotation;

    public bool mechCameraCanMove;

    // Start is called before the first frame update
    void Start()
    {
        mouseSensitivityM = PlayerPrefs.GetFloat("currentSensitivityMech", 100);

        // xSlider.value = sensX / 10;
        // ySlider.value = sensY / 10;
        slider.value = mouseSensitivityM / 10;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {

        if (endGame.deathAnim) return;

        PlayerPrefs.SetFloat("currentSensitivityMech", mouseSensitivityM);

        //get mouse input
        //float mouseX = Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityM * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityM * Time.deltaTime;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        mechOrientation.rotation = Quaternion.Euler(0, yRotation, 0);

        mechBody.Rotate(Vector3.up * mouseX);
    }

    public void AdjustMouseSens()
    {
        mouseSensitivityM = slider.value * 10;
    }
}
