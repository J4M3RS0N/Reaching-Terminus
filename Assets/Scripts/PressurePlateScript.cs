using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    [SerializeField] private GameObject plateWall;

    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;

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
        if (other.gameObject.tag == plateTag)
        {
            //plateWall.transform.position += new Vector3(0, 6, 0);

            activePlate = true;

            Debug.Log("On Platform");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == plateTag)
        {
            //plateWall.transform.position -= new Vector3(0, 6, 0);

            activePlate = false;

            Debug.Log("Left Platform");
        }
    }

    
}
   
