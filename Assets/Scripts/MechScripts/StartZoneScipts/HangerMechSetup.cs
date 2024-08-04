using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangerMechSetup : MonoBehaviour
{
    [Header("Changing Cargo Mesh")]
    public GameObject mechCargoModel;
    IEnumerator attatchingCargo;

    [Header("Dropping Mech")]
    Rigidbody mechrb;
    IEnumerator mechDrop;

    // Start is called before the first frame update
    void Start()
    {
        //Setting Cargo Mesh and Coroutine
        mechCargoModel.GetComponent<MeshRenderer>().enabled = false;
        attatchingCargo = AttatchingCargo();

        //Defining dropping Coroutine
        mechrb = GetComponent<Rigidbody>();
        mechDrop = MechDrop();
    }

    public IEnumerator AttatchingCargo()
    {
        yield return new WaitForSeconds(2);
        mechCargoModel.GetComponent<MeshRenderer>().enabled = true;
    }

    public IEnumerator MechDrop()
    {
        yield return new WaitForSeconds(4.2f);
        mechrb.isKinematic = false;
        yield return new WaitForSeconds(2);
        mechrb.isKinematic = true;
    }

    public void TurnOnCargoMesh()
    {
        StartCoroutine(attatchingCargo);
        StartCoroutine(mechDrop);
    }
}
