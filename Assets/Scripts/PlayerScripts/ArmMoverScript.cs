using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMoverScript : MonoBehaviour
{
    public Animator armAnimator;

    [SerializeField] private GameObject keyInHandObj;

    [Header("Audio")]
    private AudioSource armAudio;
    [SerializeField] private AudioClip armMoveAudio;

    [Header("PauseState")]
    public bool armPaused;

    // Start is called before the first frame update
    void Start()
    {
        armAnimator = GetComponent<Animator>();
        armAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SAVED_PlayerMovement.pmInstance.playerActive && Input.GetKeyDown(KeyCode.Tab))
        {
            armAnimator.SetBool("ShowArm", true);
            armAudio.PlayOneShot(armMoveAudio);
        }

        if (SAVED_PlayerMovement.pmInstance.playerActive && Input.GetKeyUp(KeyCode.Tab))
        {
            armAnimator.SetBool("ShowArm", false);
            armAudio.PlayOneShot(armMoveAudio);
        }

        if(KeyScript.TunnelKey.keyBool == true)
        {
            keyInHandObj.SetActive(true);
        }

        if(KeyScript.TunnelKey.keyBool == false)
        {
            keyInHandObj.SetActive(false);
        }
    }
}
