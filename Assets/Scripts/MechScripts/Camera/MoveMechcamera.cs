using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMechcamera : MonoBehaviour
{
    //[SerializeField] GameObject mechObj;
    public Transform mechCameraPosition;

    // Update is called once per frame
    private void Update()
    {
        transform.position = mechCameraPosition.position;
        //mechObj.transform.Rotate (mechCameraPosition.rotation);
    }
}
