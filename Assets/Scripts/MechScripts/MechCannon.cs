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
    public GameObject rockSpray;
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
            if (GameManager.current.gamePaused) return;
            if (ToastCollector.instance.running == false) return;
            if (ToastCollector.instance.currentHealth == 0) return;

            nextTimeToFire = Time.time + 1f / cannonFirerate;
            mechUIAnim.SetTrigger("ShotsFired");
            Shoot();
        }

    }
    void Shoot()
    {
        muzzleFlash.Play();

        shake.ShakeTheCamera();
        cannonAudio.PlayOneShot(firingSound);

        RaycastHit hit;
        if (Physics.Raycast(mechCam.transform.position, mechCam.transform.forward, out hit, cannonRange))
        {
            Debug.Log(hit.transform.name);


            DestructableWall wall = hit.transform.GetComponent<DestructableWall>();

            BreakCraneHold craneCollider = hit.transform.GetComponent<BreakCraneHold>();

            StagDropScript stag = hit.transform.GetComponent<StagDropScript>();


            if(wall != null)
            {
                wall.WallTakeDamage(cannonDamage);
                if(wall.wallDead == true)
                {
                    GameObject rPS = Instantiate(rockSpray, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(rPS, 2f);
                }
            }

            if(craneCollider != null)
            {
                craneCollider.CraneTakeDamage(cannonDamage);
            }

            if(stag != null)
            {
                stag.DetatchStag();
            }

            GameObject impactGO = Instantiate(impactFlash, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
