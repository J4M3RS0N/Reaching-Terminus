using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateDualDoor : MonoBehaviour
{
    // door pieces
    [SerializeField] private GameObject doorL;
    [SerializeField] private GameObject doorR;

    // transform positions
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPosL;
    [SerializeField] private Transform endPosR;


    // this string lets me make any plate use any tag, so i don't have to make different scripts for each type of pressure plate
    public string plateTag;

    public float moveSpeed;

    public bool activePlate;

    // Start is called before the first frame update
    void Start()
    {
        activePlate = false;
    }

    private void Update()
    {
        if (activePlate == true)
        {

            // move Left Door
            doorL.transform.position = Vector3.MoveTowards(doorL.transform.position, endPosL.position, moveSpeed * Time.deltaTime);

            if (doorL.transform.position == endPosL.position)
            {
                return;
            }

            //move Right Door
            doorR.transform.position = Vector3.MoveTowards(doorR.transform.position, endPosR.position, moveSpeed * Time.deltaTime);

            if (doorR.transform.position == endPosR.position)
            {
                return;
            }
        }

        if (activePlate == false)
        {
            doorL.transform.position = Vector3.MoveTowards(doorL.transform.position, startPos.position, moveSpeed * Time.deltaTime);
            doorR.transform.position = Vector3.MoveTowards(doorR.transform.position, startPos.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == plateTag)
        {
            //plateWall.transform.position += new Vector3(0, 6, 0);
            activePlate = true;

            transform.position += new Vector3(0, -0.0003f, 0);

            Debug.Log("On Platform");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == plateTag)
        {
            //plateWall.transform.position -= new Vector3(0, 6, 0);
            activePlate = false;

            transform.position += new Vector3(0, 0.0003f, 0);

            Debug.Log("Exited Platform");
        }
    }
}
