using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V3_LineLauncher : MonoBehaviour
{
    [Header("References")]
    public LineRenderer line;
    [SerializeField] private GameObject player;
    [SerializeField] private Camera playerCam;
    [SerializeField] private Transform linePos;
    public Transform targetPoint;

    [Header("Floats")]
    public float firingRange = 100f;
    public float zipSpeed;
    public float zipThrust;
    public float maxZipTime;
    private float zippingCdTimer;


    Rigidbody rb;
    public LayerMask isGrappable;
    private Vector3 grapplePoint;

    [Header("KeyCodes")]
    public KeyCode grappleKey = KeyCode.Mouse1;
    public KeyCode reelKey = KeyCode.R;

    public bool canZip;
    public bool lineConnected;
    public bool isZipping;
    //public bool droppedZip;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //canZip = false;
        line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate zipline
        if (Input.GetKeyDown(grappleKey))
        {
            ShootLine();
        }
        if (Input.GetKeyDown(reelKey))
        {
            if (lineConnected)
            {
                isZipping = !isZipping;
            }
            else
            {
                isZipping = false;
            }
        }

        line.SetPosition(0, linePos.position);

        //Zip Player to location while bool is true
        if (isZipping)
        {

            player.transform.position = Vector3.MoveTowards(player.transform.position, grapplePoint, zipSpeed * Time.deltaTime);
            rb.isKinematic = true;
            rb.useGravity = false;
        }
        else
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            //StartCoroutine(ZipBoost());
        }


    }

    private void ShootLine()
    {
        if (!canZip) return;
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, firingRange, isGrappable))
            {
                grapplePoint = hit.point;

                line.enabled = true;

                //isZipping = true;

                //create visual line for the zipline for players to see
                line.SetPosition(1, grapplePoint);

                //make player moveable
                rb.isKinematic = true;
                rb.useGravity = false;

                //this will decide if the player can reel themselves or not
                lineConnected = true;
            }

            //Stop Zipping and reset zip cooldown
            else
            {
                rb.isKinematic = false;
                rb.useGravity = true;

                line.enabled = false;

                lineConnected = false;
                isZipping = false;

                StartCoroutine(ResetZipping());
                Debug.Log("looked away from zipPoint");
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
        line.enabled = false;

        canZip = false;

        yield return new WaitForSeconds(2);

        canZip = true;
    }
}
