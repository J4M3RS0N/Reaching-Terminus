using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRb;
    private Transform objectGrabPointTransform;
    //[SerializeField] private Transform objectGrabPointGO;
    private Collider objectCollider;

    [SerializeField] private string interactText;

    private void Awake()
    {
        objectRb = GetComponent<Rigidbody>();
        objectCollider = GetComponent<Collider>();

    }
    public void Grab(Transform objectGrabPointTransform) 
    {
        //this.objectGrabPointTransform = objectGrabPointTransform;

        this.transform.SetParent(objectGrabPointTransform);
        //objectCollider.isTrigger = true;
        //objectCollider.enabled = false;
        objectRb.useGravity = false;
        //objectRb.isKinematic = true;
        objectRb.constraints = RigidbodyConstraints.FreezePosition;
        objectRb.freezeRotation = true;
    }

    public void Drop()
    {
        this.transform.SetParent(null);
        this.objectGrabPointTransform = null;
        //objectCollider.isTrigger = false;
        //objectCollider.enabled = true;
        objectRb.useGravity = true;
        //objectRb.isKinematic = false;
        objectRb.constraints = RigidbodyConstraints.None;
        objectRb.freezeRotation = false;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            //float lerpSpeed = 10f;
            //Vector3 newPosition = Vector3.Lerp(objectGrabPointTransform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            //objectRb.MovePosition(newPosition);

            objectRb.transform.position = Vector3.zero;
            objectRb.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

}
