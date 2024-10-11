using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PilotBinoculars : MonoBehaviour
{
    [SerializeField] private Camera playerCam;
    [SerializeField] private GameObject binoCanvas;
    [SerializeField] private GameObject objectCam;

    [Header("Audio")]
    [SerializeField] private AudioSource zoomAudio;
    [SerializeField] private AudioClip zIn;
    [SerializeField] private AudioClip zOut;

    public UnityEvent binoZoomIn;
    public UnityEvent binoZoomOut;
    private float originalFOV;

    private void Start()
    {
        originalFOV = playerCam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            binoZoomIn.Invoke();
        }

        if (Input.GetMouseButtonUp(1))
        {
            binoZoomOut.Invoke();
        }
    }

    public void BinoZoomIn()
    {
        playerCam.fieldOfView = 20;
        //turn off object cam stuff and enable bino soutline like in halo
        binoCanvas.SetActive(true);
        objectCam.SetActive(false);
        zoomAudio.PlayOneShot(zIn);
        //play zoom in sound
    }

    public void BinoZoomOut()
    {
        playerCam.fieldOfView = originalFOV;
        //re-enable object cam stuff and disable bino outline
        binoCanvas.SetActive(false);
        objectCam.SetActive(true);
        zoomAudio.PlayOneShot(zOut);

        //play zoom out sound
    }
}
