using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_InteractScript : MonoBehaviour
{
    public static New_InteractScript interactInstance;

    [SerializeField] private Transform playerCamTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private GameObject pickUpUI;
    [SerializeField] private LayerMask pickUpLayerMask;

    private ObjectGrabbable objectGrabbable;

    //[SerializeField] private FireExtinguisher fireExtinguisher;
    //[SerializeField] private ArmMoverScript arm;
    [SerializeField] private GameObject playerObjects;

    public bool objectisbeingheld;


    [SerializeField] private LayerMask interactLayerMask;
    public float InteractRange;

    // Start is called before the first frame update
    void Start()
    {
        interactInstance = this;
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

        //shoot raycast to enable pickup UI
        if (objectGrabbable == null)
        {
            float pickUpDistance = 1.5f;
            if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
            {
                if (objectisbeingheld == false)
                {
                    pickUpUI.SetActive(true);
                }

                if (objectisbeingheld == true)
                {
                    pickUpUI.SetActive(false);
                }
            }
            else
            {
                pickUpUI.SetActive(false);
            }
        }

        else
        {
            pickUpUI.SetActive(false);
        }


        //pickup objects
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null) //Not carrying Object, try to grab
            {
                float pickUpDistance = 1.5f;
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
        //arm.gameObject.SetActive(false);

        //putaway fire extinguisher, swap to animation when models are finished
        //fireExtinguisher.gameObject.SetActive(false);


        playerObjects.SetActive(false);
    }

    public void DropObject()
    {
        //drop currently equiped object
        objectGrabbable.Drop();
        objectGrabbable = null;
        objectisbeingheld = false;

        Debug.Log(objectGrabbable = null);

        // allow arm to animate again
        //arm.gameObject.SetActive(true);

        //bring back fire extinguisher (again replace with animation once the models done)
        //fireExtinguisher.gameObject.SetActive(true);

        playerObjects.SetActive(true);
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
