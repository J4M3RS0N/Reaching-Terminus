using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLauncherScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Camera playerCam;
    private Transform targetPoint;
    public float firingRange = 100f;
    public float zipSpeed;
    public float zipThrust;

    Rigidbody rb;

    //public bool canZip;
    public bool isZipping;
    public bool droppedZip;
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
        }

        if (Input.GetMouseButtonUp(1))
        {
            rb.isKinematic = false;
            rb.useGravity = true;

            isZipping = false;
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
            Debug.Log(hit.transform.name);

            if (hit.transform.CompareTag("LinePoint"))
            {
                isZipping = true;

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
           

            //DestructableWall wall = hit.transform.GetComponent<DestructableWall>();

            //BreakCraneHold craneCollider = hit.transform.GetComponent<BreakCraneHold>();


            //GameObject impactGO = Instantiate(targetPoint.gameObject, hit.point, Quaternion.LookRotation(hit.normal));

        }
    }

    //public void ToggleZipAbility()
    //{
    //    canZip = !canZip;

    //    if (canZip)
    //    {
    //        isZipping = true;
    //    }
    //    else
    //    {
    //        isZipping = false;
    //    }
    //}
}
