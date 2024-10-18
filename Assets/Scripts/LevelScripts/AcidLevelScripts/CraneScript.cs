using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneScript : MonoBehaviour
{
    public float craneHealth = 10;

    private SAVED_PlayerMovement Player;
    public Transform CraneSeat;

    public Animator craneAnimator;
    public GameObject attatchedContainer;
    public GameObject rampContainer;

    public Collider craneCollider;
    [SerializeField] private DestructableWall dWall;

    [SerializeField] private GameObject craneButton;

    [Header("Audio")]
    [SerializeField] private AudioSource craneAudio;
    [SerializeField] private AudioSource containerAudio;
    [SerializeField] private AudioClip movingSound;
    [SerializeField] private AudioClip droppingSound;

    [Header("Splash PS")]
    [SerializeField] private GameObject firstSplash;
    [SerializeField] private GameObject secondSplash;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<SAVED_PlayerMovement>();

        //craneCollider = GetComponent<GameObject>();
        craneCollider.GetComponent<BoxCollider>();
        craneCollider.enabled = false;

        craneAnimator = GetComponent<Animator>();
        rampContainer.SetActive(false);

        dWall.enabled = false;
    }

    public void CraneTakeDamage(float amount)
    {
        craneHealth -= amount;
        if (craneHealth <= 0f)
        {
            DropContainer();
        }
    }

    public void MoveCrane()
    {
        craneAnimator.SetBool("ActivateCrane", true);
        //craneButton.SetActive(false);
        StartCoroutine(SeatPlayer());

        craneAudio.PlayOneShot(movingSound);
    }

    public void DropContainer()
    {
        containerAudio.PlayOneShot(droppingSound);
        Debug.Log("DroppingSound");

        craneAnimator.SetBool("DropContainer", true);

        StartCoroutine(ReplaceContainer());
    }

    public IEnumerator SeatPlayer()
    {
        Player.transform.SetParent(CraneSeat);
        Player.playerCannotMove = true;
        Player.readyToJump = false;
        Player.canCrouch = false;

        yield return new WaitForSeconds(1);
        craneButton.SetActive(false);

        yield return new WaitForSeconds(4.8f);

        craneCollider.enabled = true;
        dWall.enabled = true;

        Player.transform.SetParent(null);
        Player.playerCannotMove = false;
        Player.readyToJump = true;
        Player.canCrouch = true;

    }

    public IEnumerator ReplaceContainer()
    {
        firstSplash.SetActive(true);

        yield return new WaitForSeconds(1.1f);
        attatchedContainer.SetActive(false);
        rampContainer.SetActive(true);

        secondSplash.SetActive(true);
    }
}
