using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerScript : MonoBehaviour
{
    [SerializeField] public Animator doorAnimator;
    [SerializeField] private GameObject keySprite;

    // Start is called before the first frame update
    void Start()
    {
        keySprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTunnelDoor()
    {
        keySprite.SetActive(true);
        doorAnimator.SetBool("OpenDoor", true);
    }

}
