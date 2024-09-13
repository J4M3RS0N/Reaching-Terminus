using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLauncher_V2 : MonoBehaviour
{
    public Transform cam;
    public Transform gunTip;
    public LineRenderer lr;
    public LayerMask isGrappable;

    [Header("Grapple Floats")]
    public float maxGrappleDistance;
    public float grappleDelayTime;
    public float grappleCd;
    private float grapplingCdTimer;

    public float zipSpeed;

    private Vector3 grapplePoint;

    public KeyCode grappleKey = KeyCode.Mouse1;

    private bool grappling;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(grappleKey)) StartGrapple();

        if (grapplingCdTimer > 0)
            grapplingCdTimer -= Time.deltaTime;
    }

    private void LateUpdate()
    {
        if (grappling)
        {
            lr.SetPosition(0, gunTip.position);
        }
    }

    private void StartGrapple()
    {
        if (grapplingCdTimer > 0) return;

        grappling = true;

        //here we throw the grappling hook or shoot the line
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, maxGrappleDistance, isGrappable))
        {
            grapplePoint = hit.point;
        }
        else
        {
            //if it didn't hit something on the grsapple layermask
            grapplePoint = cam.position + cam.forward * maxGrappleDistance;

            Invoke(nameof(StopGrapple), grappleDelayTime);
        }

        lr.enabled = true;
        lr.SetPosition(1, grapplePoint);

    }

    private void ExecuteGrapple()
    {
        //transform.position = Vector3.MoveTowards(transform.position, grapplePoint, zipSpeed * Time.deltaTime);
    }

    private void StopGrapple()
    {
        grappling = false;

        grapplingCdTimer = grappleCd;

        lr.enabled = false;
    }
}
