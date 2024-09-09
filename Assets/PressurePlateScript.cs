using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    [SerializeField] private GameObject plateWall;

    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;
    public float moveSpeed;

    public bool activePlate;

    // Start is called before the first frame update
    void Start()
    {
        activePlate = false;
    }

    private void Update()
    {
        if(activePlate == true)
        {
            plateWall.transform.position = Vector3.MoveTowards(plateWall.transform.position, endPos.position, moveSpeed * Time.deltaTime);

            if (plateWall.transform.position == endPos.position)
            {
                return;
            }
        }

        if (activePlate == false)
        {
            plateWall.transform.position = Vector3.MoveTowards(plateWall.transform.position, startPos.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mech")
        {
            //plateWall.transform.position += new Vector3(0, 6, 0);
            activePlate = true;

            Debug.Log("On Platform");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mech")
        {
            //plateWall.transform.position -= new Vector3(0, 6, 0);
            activePlate = false;

            Debug.Log("Left Platform");
        }
    }

    
}
   
