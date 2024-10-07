using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MechToggleCoolant : MonoBehaviour
{
    public UnityEvent mechButtonPush;
    [SerializeField] private GameObject activeObj;
    [SerializeField] private GameObject interiorActiveObj; 
    private bool buttonActive;

    [Header("Audio")]
    private AudioSource audioSource;
    [SerializeField] private AudioClip clickSFX;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)) 
        { 
            PressButton();
            ToggleButtonIcon();
        }
    }

    private void PressButton()
    {
        audioSource.PlayOneShot(clickSFX);
        mechButtonPush.Invoke();
    }
    
    private void ToggleButtonIcon()
    {
        buttonActive = !buttonActive;

        if(buttonActive) 
        { 
             activeObj.SetActive(true);
            interiorActiveObj.SetActive(true);
        }
        else
        {
            activeObj.SetActive(false);
            interiorActiveObj.SetActive(false);
        }
    }
}
