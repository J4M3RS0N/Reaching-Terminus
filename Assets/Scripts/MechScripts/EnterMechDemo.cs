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

    Rigidbody mechrb;

    [Header("Cameras")]
    public GameObject PlayerCam;
    public GameObject MechCam;
    

    public GameObject enterMechUI;

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
        embark = !embark;

        if (embark)
        {
            //Start consuming fuel
            startMechEngine.Invoke();

            //Player 
            mechMove.mechActive = true;
            mechrb.isKinematic = false;
            enterMechUI.gameObject.SetActive(false);

            //player is aprented to Mech
            Player.transform.SetParent(Mech);
            Player.gameObject.SetActive(false);
            //playerRB.isKinematic = true;

            // Camera swapping
            PlayerCam.gameObject.SetActive(false);
            MechCam.gameObject.SetActive(true);

            //Switch bool to damage the player if the mech is on fire
            playerInMech = true;
        }
        else
        {
            //Stop consuming fuel
            startMechEngine.Invoke();

            //Mech is deactivated
            mechMove.mechActive = false;
            mechrb.isKinematic = true;

            //unparent player from Mech
            Player.transform.SetParent(null);
            Player.gameObject.SetActive(true);
            //playerRB.isKinematic = true;

            //Swap cameras back so the player can see
            PlayerCam.gameObject.SetActive(true);
            MechCam.gameObject.SetActive(false);

            //stop mech collider from triggering damage when the player isn't in the mech
            playerInMech = false;
        }
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
