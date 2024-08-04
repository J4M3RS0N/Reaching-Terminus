using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFuelContainers : MonoBehaviour
{
    public Transform holderPosition;

    // Update is called once per frame
    private void Update()
    {
        transform.rotation = holderPosition.rotation;
    }
}
