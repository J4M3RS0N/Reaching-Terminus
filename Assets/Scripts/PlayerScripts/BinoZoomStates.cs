using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinoZoomStates : MonoBehaviour
{
    [SerializeField] private Camera playerCam;
    [SerializeField] private GameObject binoCanvas;
    [SerializeField] private GameObject objectCam;

    [Header("Audio")]
    [SerializeField] private AudioSource zoomInAudio;
    [SerializeField] private AudioSource zoomOutAudio;


    private float originalFOV;

    private void Awake()
    {
        originalFOV = playerCam.fieldOfView;
    }
    // Start is called before the first frame update
    void Start()
    {
        //originalFOV = playerCam.fieldOfView;
    }

    public void BinoZoomIn()
    {
        playerCam.fieldOfView = 20;
        //turn off object cam stuff and enable bino soutline like in halo
        binoCanvas.SetActive(true);
        objectCam.SetActive(false);
        zoomOutAudio.enabled = false;
        zoomInAudio.enabled = true;
        //play zoom in sound
    }

    public void BinoZoomOut()
    {
        playerCam.fieldOfView = originalFOV;
        //re-enable object cam stuff and disable bino outline
        binoCanvas.SetActive(false);
        objectCam.SetActive(true);
        zoomInAudio.enabled = false;
        zoomOutAudio.enabled = true;

        //play zoom out sound
    }

}
