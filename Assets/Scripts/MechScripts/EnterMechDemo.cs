using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterMechDemo : MonoBehaviour
{
    //public Rigidbody playerRB;
    MechMovement mechMove;
    public Transform Mech;
    public Transform Player;
    public V3_LineLauncher ll;
    public CheckForDamage dmgCheck;

    Rigidbody mechrb;

    [Header("Cameras")]
    public GameObject PlayerCam;
    public GameObject MechCam;
    public GameObject EmbarkCam;

    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private Transform chair;
    public GameObject playerCamHolder;

    public IEnumerator embarkEnumerator;
    public IEnumerator disembarkEnumerator;

    [Header("Aduio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip disembarkClip;

    [Header("GameObjects")]
    public GameObject enterMechUI;
    [SerializeField] private GameObject mechModelExtObj;
    [SerializeField] private GameObject mechModelShadowObj;
    [SerializeField] private GameObject animatedLegObj;

    [Header("Mech Bools")]
    // switches when player is within the collider that checks if they can enter the mech
    //public bool CanEmbark;

    // bool for toggle entrance button
    public bool embark;

    // switches whether the mech collider will be ffected by fires
    public bool playerInMech;

    public UnityEvent startMechEngine;


    // Start is called before the first frame update
    void Start()
    {
        //playerRB = GetComponent<Rigidbody>();

        mechMove = GetComponent<MechMovement>();
        mechrb = GetComponent<Rigidbody>();

        embarkEnumerator = EmbarkEnumerator();
        disembarkEnumerator = DisembarkEnumerator();

        mechrb.isKinematic = true;
        mechMove.mechActive = false;

        enterMechUI.gameObject.SetActive(false);

        playerInMech = false;
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.F) && CanEmbark)  // Here After Click F button and trigger is true player is driving
        //{
        //    //Start consuming fuel
        //    startMechEngine.Invoke();

        //    // After pressing F Mech Controller Script is enabled (change to movement)
        //    mechMove.mechActive = true; 
        //    mechrb.isKinematic = false;
        //    enterMechUI.gameObject.SetActive(false);

        //    // Here we parent Car with player
        //    Player.transform.SetParent(Mech);
        //    Player.gameObject.SetActive(false);
        //    //playerRB.isKinematic = true;

        //    // Camera
        //    PlayerCam.gameObject.SetActive(false);
        //    MechCam.gameObject.SetActive(true);

        //    //Switch bool to damage the player if the mech is on fire
        //    playerInMech = true;
        //}

        //if (Input.GetKeyDown(KeyCode.G) && MechMovement.instance.mechActive == true)
        //{
        //    //Stop consuming fuel
        //    startMechEngine.Invoke();

        //    // After pressing G button Mech Controller is disabled
        //    mechMove.mechActive = false; 
        //    mechrb.isKinematic = true;

        //    // Here We Unparent the Player with Car
        //    Player.transform.SetParent(null);
        //    Player.gameObject.SetActive(true);
        //    //playerRB.isKinematic = true;

        //    // Here If Player Is Not Driving So PlayerCamera turn On and Car Camera turn off

        //    PlayerCam.gameObject.SetActive(true);
        //    MechCam.gameObject.SetActive(false);

        //    //stop mech collider from triggering damage when the player isn't in the mech
        //    playerInMech = false;
        //}
    }



    public void ToggleEmbark()
    {
        //dont let player leave the mule if they are zipping
        if (ll.isZipping) return;

        //dont let player embark or disembark if they are sinking tar
        if (dmgCheck.playerInTar) return;

        embark = !embark;

        if (embark)
        {
            StartCoroutine(EmbarkEnumerator());

            ////Start consuming fuel
            //startMechEngine.Invoke();

            ////Player 
            //mechMove.mechActive = true;
            //mechrb.isKinematic = false;
            //enterMechUI.gameObject.SetActive(false);

            ////player is parented to Mech
            ////Player.transform.SetParent(Mech);
            ////Player.gameObject.SetActive(false);

            ////Swap mech models that are being renderd so shaodws show proeprly
            //mechModelExtObj.SetActive(false);
            //mechModelShadowObj.SetActive(true);
            //animatedLegObj.SetActive(true);

            //// Camera swapping
            ////PlayerCam.gameObject.SetActive(false);
            //MechCam.gameObject.SetActive(true);

            ////Switch bool to damage the player if the mech is on fire
            //playerInMech = true;
        }
        else
        {
            StartCoroutine(DisembarkEnumerator());

            ////Stop consuming fuel
            //startMechEngine.Invoke();

            ////Mech is deactivated
            //mechMove.mechActive = false;
            //mechrb.isKinematic = true;

            ////unparent player from Mech
            //Player.transform.SetParent(null);
            //Player.gameObject.SetActive(true);
            ////playerRB.isKinematic = true;

            ////Swap mech models that are being renderd so shaodws show proeprly
            //mechModelExtObj.SetActive(true);
            //mechModelShadowObj.SetActive(false);
            //animatedLegObj.SetActive(false);

            ////Swap cameras back so the player can see
            //PlayerCam.gameObject.SetActive(true);
            //MechCam.gameObject.SetActive(false);

            ////stop mech collider from triggering damage when the player isn't in the mech
            //playerInMech = false;
        }
    }

    public IEnumerator EmbarkEnumerator()
    {
        //player is parented to Mech
        Player.transform.SetParent(Mech);
        Player.gameObject.SetActive(false);
        playerCamHolder.transform.SetParent(Mech);

        //turn off player cam and enable emabrking cam
        EmbarkCam.gameObject.SetActive(true);
        PlayerCam.gameObject.SetActive(false);

        //start embarking camera animation
        animator.SetBool("EmbarkCam", true);
        yield return new WaitForSeconds(4f);

        EmbarkCam.SetActive(false);

        ActivateMech();

        yield break;
    }

    public IEnumerator DisembarkEnumerator()
    {
        DeactivateMech();

        //swivel chair back around
        EmbarkCam.SetActive(true);
        animator.SetBool("EmbarkCam", false);
        yield return new WaitForSeconds(2.5f);

        // unparent player from mech
        Player.transform.SetParent(null);
        Player.gameObject.SetActive(true);


        EmbarkCam.gameObject.SetActive(false);
        PlayerCam.gameObject.SetActive(true);
        playerCamHolder.transform.SetParent(null);

        yield break;
    }

    private void ActivateMech()
    {
        //Start consuming resources
        //startMechEngine.Invoke();

        // let the mech move when theres input
        mechMove.mechActive = true;
        mechrb.isKinematic = false;
        enterMechUI.gameObject.SetActive(false);

        //Swap mech models that are being rendered so shadows show properly
        mechModelExtObj.SetActive(false);
        mechModelShadowObj.SetActive(true);
        animatedLegObj.SetActive(true);

        // Activate mech camera
        MechCam.gameObject.SetActive(true);

        //Switch bool to damage the player if the mech is on fire
        playerInMech = true;
    }

    private void DeactivateMech()
    {
        //Stop consuming fuel
        //startMechEngine.Invoke();

        //play exiting sound
        audioSource.PlayOneShot(disembarkClip);

        //Mech is deactivated
        mechMove.mechActive = false;
        mechrb.isKinematic = true;

        //Swap mech models that are being renderd so shaodws show proeprly
        mechModelExtObj.SetActive(true);
        mechModelShadowObj.SetActive(false);
        animatedLegObj.SetActive(false);

        //Swap cameras back so the player can see
        MechCam.gameObject.SetActive(false);
        playerCamHolder.transform.Rotate(0, 180, 0);

        //stop mech collider from triggering damage when the player isn't in the mech
        playerInMech = false;
    }







    //private void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        //Debug.Log("Collided with other player");
    //        enterMechUI.gameObject.SetActive(true);
    //        CanEmbark = true;
            
    //    }
    //}

    //private void OnTriggerExit(Collider col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        enterMechUI.gameObject.SetActive(false);
    //        CanEmbark = false;
    //    }
    //}
}
