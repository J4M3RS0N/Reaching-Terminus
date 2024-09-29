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

    [Header("Audio")]
    [SerializeField] private AudioSource openAudio;
    [SerializeField] private AudioSource closeAudio;


    // this string lets me make any plate use any tag, so i don't have to make different scripts for each type of pressure plate
    public string plateTag;

    public float moveSpeed;

    public bool activePlate;

    public bool doorOpening;
    public bool doorClosing;

    // Start is called before the first frame update
    void Start()
    {
        activePlate = false;
        closeAudio.enabled = false;
        openAudio.enabled = false;
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
            doorOpening = true;

            transform.position += new Vector3(0, -0.0003f, 0);

            StartCoroutine(OpenDoorAudio());

            if (doorClosing == true)
            {
                StopCoroutine(CloseDoorAudio());
                doorClosing = false;
                closeAudio.enabled = false;
            }

            Debug.Log("On Platform");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == plateTag)
        {
            //plateWall.transform.position -= new Vector3(0, 6, 0);
            activePlate = false;
            doorClosing = true;

            transform.position += new Vector3(0, 0.0003f, 0);

            StartCoroutine(CloseDoorAudio());

            if (doorOpening == true)
            {
                StopCoroutine(OpenDoorAudio());
                doorOpening = false;
                openAudio.enabled = false;
            }

            Debug.Log("Exited Platform");
        }
    }

    private IEnumerator OpenDoorAudio()
    {
        openAudio.enabled = true;
        yield return new WaitForSeconds(2.5f);
        openAudio.enabled = false;

        doorOpening = false;
    }

    private IEnumerator CloseDoorAudio()
    {
        closeAudio.enabled = true;
        yield return new WaitForSeconds(2.5f);
        closeAudio.enabled = false;

        doorClosing = false;
    }
}
