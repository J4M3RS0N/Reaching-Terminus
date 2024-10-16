using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Events;

public class CoolantCollector : MonoBehaviour
{
    public static CoolantCollector instance;

    [SerializeField] private AnimatedResourceCollection coolantAnim;

    [Header("Coolant UI")]
    [SerializeField] private GameObject emptyButterUI;
    [SerializeField] private GameObject intemptyUI;

    public New_InteractScript intscript;

    [Header("Fire Stuff")]
    [SerializeField] public GameObject fireParticle;
    [SerializeField] private Transform fireSpawner;
    [SerializeField] private GameObject interiorFireObj;
    [SerializeField] private GameObject exteriorFireObj;
    public bool thereIsFire;

    [Header("Audio")]
    [SerializeField] private AudioSource coolantAudio;
    [SerializeField] private AudioClip collectSound;

    [SerializeField] private AudioSource emptyCoolantAudio;

    IEnumerator drainHealthCoruotine;

    [Header("CoolantHealth")]
    //Set actual health bar and stats
    public int maxHealth = 120;
    public int currentHealth;
    public HealthBar healthbar;

    // stats for healthbar inside of mech
    public int intmaxHealth = 120;
    public int intcurrentHealth;
    public HealthBar interiorHealthbar;

    [Header("Toggling Consumption")]
    public bool coolantRunning;
    [SerializeField] private Animator leverAnimator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 50;
        //healthbar.SetMaxHealth(maxHealth);
        healthbar.SetHealth(currentHealth);

        intmaxHealth = maxHealth;

        drainHealthCoruotine = HealthDrain();

        emptyButterUI.SetActive(false);
        intemptyUI.SetActive(false);

        emptyCoolantAudio.enabled = false;

        instance = this;
    }

    private void Update()
    {
        intcurrentHealth = currentHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            healthbar.SetHealth(currentHealth);

            emptyButterUI.SetActive(true);
            intemptyUI.SetActive(true );

            emptyCoolantAudio.enabled = true;

            //fireSpawner.SetActive(true);
            if (thereIsFire == false && coolantRunning == true)
            {
                //Instantiate(fireParticle, fireSpawner.position, fireSpawner.rotation, fireSpawner);

                GameObject coolantFire = Instantiate(fireParticle, fireSpawner.position, fireSpawner.rotation, fireSpawner);

                interiorFireObj.SetActive(true);
                exteriorFireObj.SetActive(true);
                thereIsFire = true;

                if(thereIsFire == false)
                {
                    interiorFireObj.SetActive(false);
                    exteriorFireObj.SetActive(false);
                    thereIsFire = false;
                }
            }

            if(thereIsFire == true && coolantRunning == true)
            {
                interiorFireObj.SetActive(true);
                exteriorFireObj.SetActive(true);
            }

            if (thereIsFire == false && coolantRunning == false)
            {
                interiorFireObj.SetActive(false);
                exteriorFireObj.SetActive(false);
                thereIsFire = false;
            }
        }

        if (currentHealth > 0)
        {
            if(thereIsFire == true)
            {
                interiorFireObj.SetActive(true);
                exteriorFireObj.SetActive(true);
            }
            if(thereIsFire == false)
            {

                interiorFireObj.SetActive(false);
                exteriorFireObj.SetActive(false);
                thereIsFire = false;

                //fireSpawner.SetActive(false);
            }
            emptyCoolantAudio.enabled = false;
            emptyButterUI.SetActive(false);
            intemptyUI.SetActive(false);
        }
    }

    public void ToggleEngine()
    {
        coolantRunning = !coolantRunning;

        if (coolantRunning)
        {
            leverAnimator.SetBool("RunCoolant", true);
            StartCoroutine(drainHealthCoruotine);
        }
        else
        {
            leverAnimator.SetBool("RunCoolant", false);
            StopCoroutine(drainHealthCoruotine);
        }
    }

    public IEnumerator HealthDrain()
    {
        while (true)
        {
            DrainHealth(3);

            yield return new WaitForSeconds(2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Butter"))
        {
            AddHealth(40);
            coolantAudio.PlayOneShot(collectSound);

            intscript.DropObject();
            Destroy(other.gameObject);
        }
    }

    void AddHealth(int addH)
    {
        coolantAnim.AnimateCoolantCollection();

        currentHealth += addH;
       

        healthbar.SetHealth(currentHealth);
    }

    void DrainHealth(int drain)
    {
        currentHealth -= drain;
        

        healthbar.SetHealth(currentHealth);
    }
}
