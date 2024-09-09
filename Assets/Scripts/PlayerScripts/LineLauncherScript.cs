using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLauncherScript : MonoBehaviour
{
    public LineRenderer line;

    [SerializeField] private GameObject player;
    [SerializeField] private Camera playerCam;
    [SerializeField] private Transform linePos;
    private Transform targetPoint;
    public float firingRange = 100f;
    public float zipSpeed;
    public float zipThrust;

    Rigidbody rb;

    public bool canZip;
    public bool isZipping;
    //public bool droppedZip;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //canZip = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate zipline
        if (Input.GetMouseButton(1))
        {
            ShootLine();
            //ToggleZipAbility();
        }

        if (Input.GetMouseButtonUp(1) && isZipping)
        {
            rb.isKinematic = false;
            rb.useGravity = true;

            isZipping = false;

            line.enabled = false;

            StartCoroutine(ZipBoost());

            Debug.Log("UnZipped");
        }

        //if (isZipping == false)
        //{
        //    //isZipping = false;
        //    rb.AddForce(playerCam.transform.forward * zipThrust);

        //    droppedZip = false;
        //}

        //if (isZipping == true)
        //{
        //    player.transform.position = Vector3.MoveTowards(player.transform.position, targetPoint.position, zipSpeed * Time.deltaTime);
        //}

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    ToggleZipAbility();
        //}

    }

    private void ShootLine()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, firingRange))
        {
            //Debug.Log(hit.transform.name);

            if (hit.transform.CompareTag("LinePoint"))
            {
                line.enabled = true;

                isZipping = true;

                //create visual line for the zipline for players to see
                line.SetPosition(0, linePos.transform.position);
                line.SetPosition(1, hit.transform.position);


                rb.isKinematic = true;
                rb.useGravity = false;
                player.transform.position = Vector3.MoveTowards(player.transform.position, hit.transform.position, zipSpeed * Time.deltaTime);
            }
            else
            {
                rb.isKinematic = false;
                rb.useGravity = true;
                //droppedZip = true;
            }


            //GameObject impactGO = Instantiate(targetPoint.gameObject, hit.point, Quaternion.LookRotation(hit.normal));

        }
    }

    private IEnumerator ZipBoost()
    {
        rb.AddForce(playerCam.transform.forward * zipThrust);

        yield return new WaitForSeconds(1);
    }

    //public void ToggleZipAbility()
    //{
    //    canZip = !canZip;

    //    if (canZip)
    //    {
    //        ShootLine();
    //    }

    //    else
    //    {
    //        rb.isKinematic = false;
    //        rb.useGravity = true;
    //        Debug.Log("Else");
    //    }
    //}
}
