using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private EndGameScript endGame;
    [SerializeField] private Slider slider;
    [SerializeField] public EnterMechDemo enterMechDemo;

    //public float sensX;
    //public float sensY;

    public float mouseSensitivity = 100;

    public Transform orientation;

    float xRotation;
    float yRotation;

    public bool cameraCanMove;

    // Start is called before the first frame update
    void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("currentSensitivity", 100);

        // xSlider.value = sensX / 10;
        // ySlider.value = sensY / 10;
        slider.value = mouseSensitivity / 10;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {

        if (endGame.deathAnim) return;

        PlayerPrefs.SetFloat("currentSensitivity", mouseSensitivity);

        //get mouse input
        //float mouseX = Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
        if (enterMechDemo.playerInMech == true) return;
        {

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        }

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void AdjustMouseSens()
    {
        mouseSensitivity = slider.value * 10;
    }

}
