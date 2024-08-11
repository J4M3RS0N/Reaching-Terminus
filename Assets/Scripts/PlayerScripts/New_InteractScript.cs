using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_InteractScript : MonoBehaviour
{


    [SerializeField] private Transform playerCamTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    private ObjectGrabbable objectGrabbable;

    [SerializeField] private FireExtinguisher fireExtinguisher;
    [SerializeField] private ArmMoverScript arm;

    public bool objectisbeingheld;


    [SerializeField] private LayerMask interactLayerMask;
    public float InteractRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    float interactDistance = 2f;
        //    if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit raycastHit, interactDistance, interactLayerMask))
        //        if (raycastHit.transform.TryGetComponent(out IIteractable iteractable))
        //        {

        //        }
        //}

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null) //Not carrying Object, try to grab
            {
                float pickUpDistance = 1f;
                if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectisbeingheld = true;
                        GrabObject();
                    }
            }
            else //Currently carrying an Object, drop
            {
                objectisbeingheld = false;
                DropObject();

            }

            //IIteractaballs interactable = GetInteractaballs();
            //if (interactable != null)
            //{
            //    interactable.Interact();
            //}


            Ray r = new Ray(playerCamTransform.position, playerCamTransform.forward);
            Debug.DrawRay(r.origin, r.direction, Color.red);
            if (Physics.Raycast(r, out RaycastHit hit, InteractRange, interactLayerMask))
            {
                if (hit.collider.TryGetComponent(out IIteractable interactable))
                {
                    interactable.Interact(transform);
                }
            }

        }

    }


    public void GrabObject()
    {
        //Grab Object and Freeze Variables 
        objectGrabbable.Grab(objectGrabPointTransform);
        objectGrabbable.transform.position = objectGrabPointTransform.transform.position;
        objectGrabbable.transform.rotation = objectGrabPointTransform.transform.rotation;

        //Stop player arm from moving;
        arm.gameObject.SetActive(false);

        //putaway fire extinguisher, swap to animation when models are finished
        fireExtinguisher.gameObject.SetActive(false);

    }

    public void DropObject()
    {
        //drop currently equiped object
        objectGrabbable.Drop();
        objectGrabbable = null;
        Debug.Log(objectGrabbable = null);

        // allow arm to animate again
        arm.gameObject.SetActive(true);

        //bring back fire extinguisher (again replace with animation once the models done)
        fireExtinguisher.gameObject.SetActive(true);
    }


    //public void GetInteractable(GameObject objectToInteractWith)
    //{
    //    if (objectToInteractWith.TryGetComponent(out IIteractaballs interactable))
    //    {
    //        interactable.Interact(transform);

    //    }
    //}

    //public IIteractaballs GetInteractaballs()
    //{
    //    Ray r = new Ray(playerCamTransform.position, playerCamTransform.forward);
    //    if (Physics.Raycast(r, out RaycastHit hit, InteractRange))
    //    {
    //        if (hit.collider.TryGetComponent(out IIteractaballs interactable))
    //        {
    //            interactable.Interact();
    //        }
    //    }
    //}

    public SimpleButton GetSimpleButton()
    {
        Ray r = new Ray(playerCamTransform.position, playerCamTransform.forward);
        if (Physics.Raycast(r, out RaycastHit hit, InteractRange, interactLayerMask))
        {
            if (hit.collider.TryGetComponent(out SimpleButton button))
            {
                return button;
            }
        }

        return null;
    }

}
