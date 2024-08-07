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
    }

    private void Update()
    {

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            healthbar.SetHealth(currentHealth);

            emptyToastUI.SetActive(true);
            intemptyUI.SetActive(true);
        }

        if(currentHealth > 0)
        {
            emptyToastUI.SetActive(false);
            intemptyUI.SetActive(false);
        }
    }

    public void ToggleEngine()
    {
        running = !running;

        if (running)
        {
            GetComponent<MeshRenderer>().material = turnedOnMaterial;
           StartCoroutine(drainHealthCoruotine);
        }
        else
        {
            GetComponent<MeshRenderer>().material = turnedOffMaterial;
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
        if (other.gameObject.CompareTag("Toast"))
        {
            AddHealth(30);
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
