using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerGate : MonoBehaviour
{
    public Animator hangerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //hangerAnimator =  GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Mech")
        {
            hangerAnimator.SetBool("LowerGate", true);
        }
    }
}
