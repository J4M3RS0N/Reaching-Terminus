using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PilotBinoculars : MonoBehaviour
{

    public UnityEvent OnZoomIn;
    public UnityEvent OnZoomOut;

    private bool zoom;

    //[SerializeField] private Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //binoZoomIn?.Invoke();
            //change bino animation
            //OnZoomIn?.Invoke();

            ToggleZoom();
        }

        //if (Input.GetMouseButtonUp(1))
        //{
        //    //binoZoomOut?.Invoke();
        //    //chnage bino animation
        //    OnZoomOut?.Invoke();
        //}
    }

    private void ToggleZoom()
    {
        zoom = !zoom;

        if (zoom)
        {
            OnZoomIn?.Invoke();
        }
        else
        {
            OnZoomOut?.Invoke();
        }
    }
}
