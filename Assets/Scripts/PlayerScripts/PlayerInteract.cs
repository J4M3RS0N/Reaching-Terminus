using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] private Transform playerCamTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    private ObjectGrabbable objectGrabbable;

    // Update is called once per frame
    void Update()
    {

        //Player Pickup Objects
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(objectGrabbable == null) //Not carrying Object, try to grab
            {
                float pickUpDistance = 2f;
                if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                    }
            }
            else //Currently carrying an Object, drop
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
            }

            // Interacting with Buttons and Switches
            IIteractable interactable = GetInteractableObject();
            if(interactable != null)
            {
                interactable.Interact(transform);
            }
        }
    }

    public IIteractable GetInteractableObject()
    {
        List<IIteractable> interactableList = new List<IIteractable>();
        float interactRange = 0.8f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out IIteractable interactable))
            {
                interactableList.Add(interactable);
            }
        }

        IIteractable closestInteractable = null;
        foreach (IIteractable interactable in interactableList)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else
            {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) < 
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position))

                {
                    closestInteractable = interactable;
                }
            }
        }

        return closestInteractable;
    }
   
}
