using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckAudio : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip landedSFX;
    public LayerMask groundLayer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            audioSource.PlayOneShot(landedSFX);
        }
    }
}
