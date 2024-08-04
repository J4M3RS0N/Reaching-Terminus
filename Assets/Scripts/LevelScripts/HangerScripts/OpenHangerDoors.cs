using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHangerDoors : MonoBehaviour
{
    Animator hangerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        hangerAnimator = GetComponent<Animator>();
    }

    public void PlayDoorOpenAnim()
    {
        hangerAnimator.SetBool("OpenDoors", true);
    }
}
