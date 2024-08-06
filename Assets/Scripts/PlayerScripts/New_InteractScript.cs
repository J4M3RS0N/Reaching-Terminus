using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_InteractScript : MonoBehaviour
{
    [SerializeField] private Transform playerCamTransform;
    [SerializeField] private LayerMask interactLayerMask;
    public float InteractRange;

    public bool objectIsInteractable;

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
            Ray r = new Ray(playerCamTransform.position, playerCamTransform.forward);
            if (Physics.Raycast(r, out RaycastHit hit, InteractRange))
            {
                if (hit.collider.TryGetComponent(out IIteractable interactable))
                {
                    interactable.Interact(transform);
                }
            }
        }
    }

    public void GetInteractable(GameObject objectToInteractWith)
    {
        if (objectToInteractWith.TryGetComponent(out IIteractable interactable))
        {
            interactable.Interact(transform);
        }
    }

    public SimpleButton GetSimpleButton()
    {
        Ray r = new Ray(playerCamTransform.position, playerCamTransform.forward);
        if (Physics.Raycast(r, out RaycastHit hit, InteractRange))
        {
            if (hit.collider.TryGetComponent(out SimpleButton button))
            {
                return button;
            }
        }

        return null;
    }

}
