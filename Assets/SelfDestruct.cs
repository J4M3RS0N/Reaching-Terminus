using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private EndGameScript endGame;
    [SerializeField] private PlayerHealth ph;
    [SerializeField] private ShakeCamera camShake;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject explosionFire;

    public Slider slider;
    public bool selfDestruct;

    private void Awake()
    {
        slider.value = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            slider.value += Time.deltaTime;

            //play some warning sounds and flashing red lights

            if(slider.value == 3)
            {
                //begin self destruct sequence
                //Set explosion ps with damaging collider active, and stoip players from leaving mech in other scripts, which should kill them
                camShake.ShakeTheCamera();
                explosion.SetActive(true);
                explosionFire.SetActive(true);
                
            }
        }
    }
}
