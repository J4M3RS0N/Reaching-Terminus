using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    [SerializeField] private GameObject plateWall;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mech")
        {
            plateWall.transform.position += new Vector3(0, 6, 0);

            Debug.Log("On Platform");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mech")
        {
            plateWall.transform.position -= new Vector3(0, 6, 0);

            Debug.Log("Left Platform");
        }
    }
}
   
