using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireV2 : MonoBehaviour
{
    public int maxHealth = 3;
    public int currenthealth;


    [SerializeField] private ParticleSystem[] particleSystems = new ParticleSystem[0];
    public int startIntensity = 25;
    public int currentIntensity;


    // Start is called before the first frame update
    void Start()
    {
        currentIntensity = startIntensity;

        currenthealth = maxHealth;
    }

    private void Update()
    {
        //TakeDamage();

    }

    public bool TryExtinguish(int fire)
    {
        currentIntensity -= fire;

        ChangeIntensity();

        return currentIntensity <= 0;
    }

    void ReduceIntensity(int drain)
    {
        currentIntensity -= drain;

        //healthbar.SetHealth(currentHealth);
    }

    private void ChangeIntensity()
    {
        for (int i = 0; i < particleSystems.Length; i++)
        {
            var emission = particleSystems[i].emission;
            emission.rateOverTime = currentIntensity * startIntensity;
        }
    }

    public void TakeDamage(int amount)
    {
        currenthealth -= amount;
        Debug.Log(currenthealth);



        if (currenthealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
