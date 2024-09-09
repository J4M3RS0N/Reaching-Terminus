using UnityEngine;

public class MechCannon : MonoBehaviour
{
    public float cannonDamage = 10f;
    public float cannonRange = 100f;
    public float cannonFirerate = 0.5f;

    public Animator mechUIAnim;

    public ShakeCamera shake;

    public Camera mechCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactFlash;

    [Header("Audio")]
    private AudioSource cannonAudio;
    [SerializeField] private AudioClip firingSound;

    //[SerializeField] 

    private float nextTimeToFire = 0f;

    private void Start()
    {
        //mechUIAnim = GetComponent<Animator>();
        cannonAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / cannonFirerate;
            mechUIAnim.SetTrigger("ShotsFired");
            Shoot();
        }

    }
    void Shoot()
    {
        if (MechMovement.instance.mechCannotMove == true) return;
        if (ToastCollector.instance.currentHealth <= 0) return;

        muzzleFlash.Play();

        shake.ShakeTheCamera();
        cannonAudio.PlayOneShot(firingSound);

        RaycastHit hit;
        if (Physics.Raycast(mechCam.transform.position, mechCam.transform.forward, out hit, cannonRange))
        {
            Debug.Log(hit.transform.name);


            DestructableWall wall = hit.transform.GetComponent<DestructableWall>();

            BreakCraneHold craneCollider = hit.transform.GetComponent<BreakCraneHold>();


            if(wall != null)
            {
                wall.WallTakeDamage(cannonDamage);
            }

            if(craneCollider != null)
            {
                craneCollider.CraneTakeDamage(cannonDamage);
            }

            GameObject impactGO = Instantiate(impactFlash, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
