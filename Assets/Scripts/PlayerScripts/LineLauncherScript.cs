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
            StartCoroutine(ResetZipping());

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
        if (canZip)
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, firingRange))
            {
                //start zipping if we hit a zipPoint
                if (hit.transform.CompareTag("LinePoint"))
                {
                    line.enabled = true;

                    isZipping = true;

                    //create visual line for the zipline for players to see
                    line.SetPosition(0, linePos.transform.position);
                    line.SetPosition(1, hit.transform.position);

                    //make player moveable
                    rb.isKinematic = true;
                    rb.useGravity = false;
                    //zip player to the zip point hit by their raycast
                    player.transform.position = Vector3.MoveTowards(player.transform.position, hit.transform.position, zipSpeed * Time.deltaTime);
                }
                //Stop Zipping and reset zip cooldown
                else 
                {
                    rb.isKinematic = false;
                    rb.useGravity = true;

                    line.enabled = false;

                    isZipping = false;

                    StartCoroutine(ResetZipping());
                }


                //GameObject impactGO = Instantiate(targetPoint.gameObject, hit.point, Quaternion.LookRotation(hit.normal));

            }
        }
    }

    private IEnumerator ZipBoost()
    {
        // boost player forward when the leave a zipine 

        rb.AddForce(playerCam.transform.forward * zipThrust);

        yield return new WaitForSeconds(1);
    }

    private IEnumerator ResetZipping()
    {
        //zip cooldown function

        canZip = false;

        yield return new WaitForSeconds(2);

        canZip = true;
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
