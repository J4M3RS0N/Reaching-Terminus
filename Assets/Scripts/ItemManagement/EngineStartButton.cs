using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineStartButton : MonoBehaviour, IIteractable
{
    [SerializeField] private MeshRenderer buttonMeshRenderer;
    [SerializeField] private Material pickUpMaterial;
    [SerializeField] private Material blueM;

    [SerializeField] private string interactText;



    ToastCollector toastCollector;
    [SerializeField] GameObject toastHolder;

    public bool isColorOrange;

    private void Start()
    {
        toastCollector = toastHolder.GetComponent<ToastCollector>(); 
    }

    private void SetColorBlue()
    {
        buttonMeshRenderer.material = blueM;
        toastCollector.running = false;
    }

    private void SetColorOrange()
    {
        buttonMeshRenderer.material = pickUpMaterial;
        toastCollector.running = true;

    }

    private void ToggleEngine()
    {
        isColorOrange = !isColorOrange;
        if (isColorOrange)
        {
            SetColorOrange();
        }
        else
        {
            SetColorBlue();
        }
    }

    private void PushButton()
    {
        ToggleEngine();
    }

    public void Interact(Transform interactorTransform)
    {
        PushButton();
    }

    public string GetInteractText()
    {
        return "Push Button";
    }


    public Transform GetTransform()
    {
        return transform;
    }
}
