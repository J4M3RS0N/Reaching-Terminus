using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMoverScript : MonoBehaviour
{
    public Animator armAnimator;

    // Start is called before the first frame update
    void Start()
    {
        armAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SAVED_PlayerMovement.pmInstance.playerActive && Input.GetKeyDown(KeyCode.Tab))
        {
            armAnimator.SetBool("ShowArm", true);
        }

        if (SAVED_PlayerMovement.pmInstance.playerActive && Input.GetKeyUp(KeyCode.Tab))
        {
            armAnimator.SetBool("ShowArm", false);
        }
    }
}
