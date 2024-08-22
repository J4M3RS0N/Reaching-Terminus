using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRb;
    private Transform objectGrabPointTransform;
    private Collider objectCollider;

    [Header("Audio")]
    private AudioSource objectAudio;

    public AudioClip pickUpAudio;
    public AudioClip dropAudio;

    [SerializeField] private string interactText;

    private void Awake()
    {
        objectRb = GetComponent<Rigidbody>();
        objectCollider = GetComponent<Collider>();
        objectAudio = GetComponent<AudioSource>();
    }
    public void Grab(Transform objectGrabPointTransform) 
    {
        this.transform.SetParent(objectGrabPointTransform);
        objectRb.useGravity = false;

        //Constrain Rigibody
        objectRb.constraints = RigidbodyConstraints.FreezePosition;
        objectRb.freezeRotation = true;

        //play audio clip
        objectAudio.PlayOneShot(pickUpAudio);
    }

    public void Drop()
    {
        this.transform.SetParent(null);
        this.objectGrabPointTransform = null;

        objectRb.useGravity = true;

        //Unrestrict Rigidbody
        objectRb.constraints = RigidbodyConstraints.None;
        objectRb.freezeRotation = false;

        //play audio clip
        objectAudio.PlayOneShot(dropAudio);
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            objectRb.transform.position = Vector3.zero;
            objectRb.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
