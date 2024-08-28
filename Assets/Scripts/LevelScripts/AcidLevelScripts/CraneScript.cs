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

    public GameObject craneCollider;

    [SerializeField] private GameObject craneButton;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<SAVED_PlayerMovement>();

        //craneCollider = GetComponent<GameObject>();
        craneCollider.GetComponent<BoxCollider>();
        craneCollider.SetActive(false);

        craneAnimator = GetComponent<Animator>();
        rampContainer.SetActive(false);
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
        craneButton.SetActive(false);
        StartCoroutine(SeatPlayer());
    }

    public void DropContainer()
    {
        craneAnimator.SetBool("DropContainer", true);
        StartCoroutine(ReplaceContainer());
    }

    public IEnumerator SeatPlayer()
    {
        Player.transform.SetParent(CraneSeat);
        yield return new WaitForSeconds(5.8f);
        craneCollider.SetActive(true);
        Player.transform.SetParent(null);

    }

    public IEnumerator ReplaceContainer()
    {
        yield return new WaitForSeconds(1.1f);
        attatchedContainer.SetActive(false);
        rampContainer.SetActive(true);
    }
}
