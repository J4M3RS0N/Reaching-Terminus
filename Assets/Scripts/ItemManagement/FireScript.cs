using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    //public static FireScript instance;

    [Header("Fire Health")]
    public int maxHealth = 3;
    public int currenthealth;

    [Header("Player Fields")]
    public bool playerInCollider;

    [SerializeField, Range(0f, 1f)] private float currentIntensity = 1f;
    private float[] startIntensities = new float[0];

    [SerializeField] private ParticleSystem [] particleSystems = new ParticleSystem[0];

    [Header("Audio")]
    private AudioSource fireAudio;

    // Start is called before the first frame update
    void Start()
    {
        //instance = this;

        startIntensities = new float[particleSystems.Length];

        for (int i = 0; i < particleSystems.Length; i++)
        {
            startIntensities[i] = particleSystems[i].emission.rateOverTime.constant;
        }

        currenthealth = maxHealth;

        fireAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //TakeDamage();
    }

  

    public bool TryExtinguish(float fire)
    {
        currentIntensity -= fire;

        ChangeIntensity();

        return currentIntensity <= 0;
    }

    private void ChangeIntensity()
    {
        for (int i = 0; i < particleSystems.Length; i++)
        {
            var emission = particleSystems[i].emission;
            emission.rateOverTime = (currenthealth / 2); //* startIntensities[i];
        }
    }

    public IEnumerator DissipateFire()
    {
        while (true)
        {

           yield return new WaitForSeconds(1.5f);
           Destroy(gameObject);


        }
    }

    public void TakeDamage(int amount)
    {
        currenthealth -= amount;
        Debug.Log(currenthealth);



        if (currenthealth <= 0)
        {
            StartCoroutine(DissipateFire());
        }
    }

}
