using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerGate : MonoBehaviour
{
    public Animator hangerAnimator;

    [SerializeField] private AudioSource gateAudio;
    [SerializeField] private AudioClip openGateSound;

    IEnumerator destroyCollider;
    // Start is called before the first frame update
    void Start()
    {
        //hangerAnimator =  GetComponent<Animator>();
        destroyCollider = DestroyCollider();
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
            gateAudio.PlayOneShot(openGateSound);
            StartCoroutine(DestroyCollider());
        }
    }

    private IEnumerator DestroyCollider()
    {
        yield return new WaitForSeconds(2.3f);

        Destroy(this.gameObject);
    }
}
