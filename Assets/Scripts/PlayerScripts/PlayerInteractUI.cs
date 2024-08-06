using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{

    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private New_InteractScript newPI;
    [SerializeField] private TextMeshProUGUI interactTMPGUI;


    private void Update()
    {
        //if (playerInteract.GetInteractableObject() != null)
        //{
        //    Show(playerInteract.GetInteractableObject());
        //}
        //else
        //{
        //    Hide();
        //}

        if (newPI.GetSimpleButton() != null)
        {
            Show();
        }
        else
        {
            Hide();
        }


    }

    //private void Show(IIteractable interactable)
    //{
    //    containerGameObject.SetActive(true);
    //    interactTMPGUI.text = interactable.GetInteractText();
    //}

    private void Show()
    {
        containerGameObject.SetActive(true);
       // interactTMPGUI.text = interactable.GetInteractText();
    }

    private void Hide()
    {
        containerGameObject.SetActive(false);
    }


}
