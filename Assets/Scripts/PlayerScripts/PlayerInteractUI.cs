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

    //private SimpleButton simpB;

    private void Update()
    {

        if (newPI.GetSimpleButton() != null)
        {
            Show(newPI.GetSimpleButton());
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

    private void Show(SimpleButton button)
    {
        containerGameObject.SetActive(true);
        interactTMPGUI.text = button.GetInteractText();
    }

    private void Hide()
    {
        containerGameObject.SetActive(false);
    }


}
