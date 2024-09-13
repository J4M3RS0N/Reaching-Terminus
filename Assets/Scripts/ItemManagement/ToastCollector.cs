using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.UI;
using UnityEngine;

public class ToastCollector : MonoBehaviour
{
    public static ToastCollector instance;

    [SerializeField] private Material turnedOffMaterial;
    [SerializeField] private Material turnedOnMaterial;
    [SerializeField] private GameObject emptyToastUI;
    [SerializeField] private GameObject intemptyUI;

    public New_InteractScript intscript;

    [Header("Audio")]
    private AudioSource fuelAudio;
    [SerializeField] private AudioSource engineAudio;

    [SerializeField] private AudioClip collectSound;
    [SerializeField] private AudioClip breakdownSound;

    [SerializeField] private AudioSource emptyFuelAudio;

    private bool playBreakdownClip;
    private bool hasPlayed;

    [Header("Health")]
    IEnumerator drainHealthCoruotine;

    // stats for player monitor
    public int maxHealth = 120;
    public int currentHealth;
    public HealthBar healthbar;

    // stats for healthbar inside of mech
    public int intmaxHealth = 120;
    public int intcurrentHealth;
    public HealthBar interiorHealthbar;

    public bool running;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //currentHealth = maxHealth;
        currentHealth = 30;
        //healthbar.SetMaxHealth(maxHealth);
        healthbar.SetHealth(currentHealth);

        intmaxHealth = maxHealth;

        drainHealthCoruotine = HealthDrain();

        emptyToastUI.SetActive(false);
        intemptyUI.SetActive(false);

        fuelAudio = GetComponent<AudioSource>();
        emptyFuelAudio.enabled = false;
    }

    private void Update()
    {

        if (currentHealth <= 0 && !playBreakdownClip)
        {
            currentHealth = 0;
            healthbar.SetHealth(currentHealth);

            emptyToastUI.SetActive(true);
            intemptyUI.SetActive(true);

            engineAudio.enabled = false;

            emptyFuelAudio.enabled = true;

            if (!hasPlayed)
            {
                playBreakdownClip = true;
            }
        }

        if(currentHealth > 0)
        {
            emptyToastUI.SetActive(false);
            intemptyUI.SetActive(false);

            emptyFuelAudio.enabled = false;
        }

        if (playBreakdownClip)
        {
            hasPlayed = true;
            fuelAudio.PlayOneShot(breakdownSound, 0.6f);
            playBreakdownClip = false;
        }

    }

    public void ToggleEngine()
    {
        running = !running;

        if (running)
        {
            GetComponent<MeshRenderer>().material = turnedOnMaterial;
           //StartCoroutine(drainHealthCoruotine);

            engineAudio.enabled = true;
        }
        else
        {
            GetComponent<MeshRenderer>().material = turnedOffMaterial;
           //StopCoroutine(drainHealthCoruotine);

            engineAudio.enabled = false;
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
        if (other.gameObject.CompareTag("Toast"))
        {
            AddHealth(30);
            fuelAudio.PlayOneShot(collectSound);

            intscript.DropObject();
            Destroy(other.gameObject);
        }
    }

    void AddHealth(int addH)
    {
        currentHealth += addH;

        healthbar.SetHealth(currentHealth);
    }

    void DrainHealth(int drain)
    {
        currentHealth -= drain;

       healthbar.SetHealth(currentHealth);
    }
}
