using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireExtinguisher : MonoBehaviour
{
    public UnityEvent OnExtinguisherShoot;
    public float ShootCooldown;
    private float CurrentCooldown;

    [SerializeField] private GameObject extinguishPS;
    [SerializeField] private GameObject reloadText;

    // ammo floats
    //public float ammo = 1f;
    //private float maxAmmo = 1f;

    public int maxAmmo = 300;
    public int currentAmmo;
    public HealthBar healthbar;

    public float fireRate = 15f;
    private float nextTimeToShoot = 0f;

    //in case I want to make it semi-auto later
    public bool automatic;
    public bool canShoot;
    public bool firing = false;

    [Header("Audio")]
    private AudioSource extinguisherAudio;


    // Start is called before the first frame update
    void Start()
    {
        CurrentCooldown = ShootCooldown;

        canShoot = true;

        reloadText.SetActive(false);

        currentAmmo = maxAmmo;
        healthbar.SetHealth(currentAmmo);

        extinguisherAudio = GetComponent<AudioSource>();

        //ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo > 0 && canShoot == true)
        {
            if (GameManager.current.gamePaused) return;
            // if the player is pressing mouse button and the fire time is right and they have ammo
            if (Input.GetMouseButton(0) && Time.time >= nextTimeToShoot)
            {
                nextTimeToShoot = Time.time + 1f / fireRate;
                OnExtinguisherShoot?.Invoke();

                //set firing bool to true
                firing = true;

                //deplete ammo
                currentAmmo -= 5;
                healthbar.SetHealth(currentAmmo);

                //shake the player camera
                //playerCamShake.ShakeTheCamera();

                extinguishPS.SetActive(true);

                extinguisherAudio.enabled = true;

                CurrentCooldown = ShootCooldown;
            }
        }

        //if the player is shooting enable particle system
        if (Input.GetMouseButtonUp(0) && canShoot)
        {
            extinguishPS.SetActive(false);

            firing = false;

            extinguisherAudio.enabled = false;
        }

        // if player isnt shooting disable particle system
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            extinguishPS.SetActive(true);
            extinguisherAudio.enabled = true;
        }

        // regenerate Ammo
        if (firing == false && Time.time >= nextTimeToShoot && currentAmmo >= 0)
        {
            nextTimeToShoot = Time.time + 1f / fireRate;

            currentAmmo += 4;
            healthbar.SetHealth(currentAmmo);
        }

        //resetting firing when ammo is maxxed
        if (currentAmmo == maxAmmo)
        {
            reloadText.SetActive(false);

            canShoot = true;

            healthbar.SetHealth(currentAmmo);
        }

        //stop player from shooting when they run out of ammo
        if (currentAmmo == 0 && Time.time >= nextTimeToShoot)
        {
            nextTimeToShoot = Time.time + 1f / fireRate;

            canShoot = false;
            firing = false;

            reloadText.SetActive(true);

            extinguishPS.SetActive(false);

            extinguisherAudio.enabled = false;

            healthbar.SetHealth(currentAmmo);
        }

        // when ammo reaches 100 or more, is set to max ammo
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
            healthbar.SetHealth(currentAmmo);
        }

        //if ammo is below 0, set to 0
        if (currentAmmo < 0f)
        {
            currentAmmo = 0;
            healthbar.SetHealth(currentAmmo);
        }

        CurrentCooldown -= Time.deltaTime;
    }
}
