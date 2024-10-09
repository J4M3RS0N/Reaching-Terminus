using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockoutMech : MonoBehaviour
{
    //use ontrigger enter for mech, and toggle mech embark function on mech to boot out player, then lcok mech dorr through embark animations or new animation

    [SerializeField] private EnterMechDemo mechEmabrk;
    [SerializeField] private Transform mechHolder;
    [SerializeField] private GameObject enterMechButton;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Mech")
        {
            //parent mech to elevator platform
            Transform mechBody = other.transform.parent;
            mechBody.SetParent(mechHolder);

            //set the mechs position and rotation ot the mech platforms
            mechBody.position = mechHolder.position;
            mechBody.rotation = mechHolder.rotation;

            //force the pilot to exit the mech
            mechEmabrk.ToggleEmbark();

            //disable pilot's ability to re-enter the mech
            enterMechButton.SetActive(false);

            //send the trigger collider away to avoid repeating mech embark toggle, and allow the registration of the collider becoming null
            transform.position = new Vector3(-1, -1, -1);
            //boxCollider.enabled = false;  move thee box cvollider so the script can register it has become null
            //StartCoroutine(mechEmabrk.disembarkEnumerator);
            //close up the back of the mech and disable fuel and coolant consumption, end all fires, turn off noises from mech
            //OR turn off mechdemo, and have standin model mesh swap in with the stand
        }
    }
}
