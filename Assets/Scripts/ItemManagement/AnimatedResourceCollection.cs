using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedResourceCollection : MonoBehaviour
{
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateFuelCollection()
    {
        animator.SetTrigger("FuelTrigger");
    }

    public void AnimateCoolantCollection()
    {
        animator.SetTrigger("CoolantTrigger");

    }
}
