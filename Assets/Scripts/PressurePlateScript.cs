using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    [SerializeField] private GameObject plateWall;

    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;

    [SerializeField] private AudioSource moveTowardsAudio;
    [SerializeField] private AudioSource returnAudio;

    // this string lets me make any plate use any tag, so i don't have to make different scripts for each type of pressure plate
    public string plateTag;

    public float moveSpeed;

    public bool activePlate;
    public bool platMoving;

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

            returnAudio.enabled = false;
            moveTowardsAudio.enabled = true;

            if (plateWall.transform.position == endPos.position)
            {
                moveTowardsAudio.enabled = false;
                return;
            }
        }

        if (activePlate == false)
        {
            plateWall.transform.position = Vector3.MoveTowards(plateWall.transform.position, startPos.position, moveSpeed * Time.deltaTime);

            moveTowardsAudio.enabled = false;
            returnAudio.enabled = true;

            if (plateWall.transform.position == startPos.position)
            {
                returnAudio.enabled = false;
                return;
            }
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
   
