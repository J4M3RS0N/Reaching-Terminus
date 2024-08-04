using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRb;
    private Transform objectGrabPointTransform;
    private Collider objetCollider;

    //[SerializeField] private string interactText;

    private void Awake()
    {
        objectRb = GetComponent<Rigidbody>();
        objetCollider = GetComponent<Collider>();

    }
    public void Grab(Transform objectGrabPointTransform) 
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        //objetCollider.isTrigger = true;
        objectRb.useGravity = false;
        objectRb.isKinematic = true;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        //objetCollider.isTrigger = false;
        objectRb.useGravity = true;
        objectRb.isKinematic = false;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null) 
        {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRb.MovePosition(newPosition);
        }
    }

}
