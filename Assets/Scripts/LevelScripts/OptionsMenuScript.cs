using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuScript : MonoBehaviour
{
    [Header("Audio")]
    private AudioSource buttonAudio;
    [SerializeField] private AudioClip pressSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickSoundShot()
    {
        buttonAudio.PlayOneShot(pressSound);
    }
}
