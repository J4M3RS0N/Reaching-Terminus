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

    Rigidbody rb;

    public bool canZip;
    public bool isZipping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canZip = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate zipline
        if (Input.GetKey(KeyCode.P))
        {
            ShootLine();
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

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
                rb.isKinematic = true;
                rb.useGravity = false;
                player.transform.position = Vector3.MoveTowards(player.transform.position, hit.transform.position, zipSpeed * Time.deltaTime);
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
