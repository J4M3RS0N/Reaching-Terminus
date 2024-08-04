using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleButton : MonoBehaviour, IIteractable
{
    //ToastCollector toastCollector;
    [SerializeField] GameObject itemHolder;
    [SerializeField] private string interactText;

    public UnityEvent buttonPush;

    // Start is called before the first frame update
    void Start()
    {
       // toastCollector = itemHolder.GetComponent<ToastCollector>();
    }

    private void PushButton()
    {
        buttonPush.Invoke();
        //toastCollector.ToggleEngine();
        //currentFuelScript.ToggleEngine();
    }

    public void Interact(Transform interactorTransform)
    {
        PushButton();
    }

    public string GetInteractText()
    {
        //return "Push Button (E)";
        return interactText;
    }


    public Transform GetTransform()
    {
        return transform;
    }
}
