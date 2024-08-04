using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCargo : MonoBehaviour
{
    public GameObject newCargo;
    public GameObject doorButton;
    public GameObject cargoButton;

    IEnumerator movingCargo;
    IEnumerator unlockDoorButton;

    Animator hangerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //Components
        hangerAnimator = GetComponent<Animator>();
        newCargo.GetComponent<MeshRenderer>().enabled = true;

        //Coroutines
        movingCargo = MovingCargo();
        unlockDoorButton = UnlockDoorButton();

        //Setting Button to Starting States
        doorButton.SetActive(false);
        cargoButton.SetActive(true);
    }

    public IEnumerator MovingCargo()
    {
        yield return new WaitForSeconds(2);
        newCargo.GetComponent<MeshRenderer>().enabled = false;
    }

    public IEnumerator UnlockDoorButton()
    {
        yield return new WaitForSeconds(4.5f);
        doorButton.SetActive(true);
    }

    public void ReplaceCargo()
    {
        hangerAnimator.SetBool("AttatchCargo", true);
        StartCoroutine(movingCargo);
        StartCoroutine(unlockDoorButton);
        cargoButton.SetActive(false);
    }
}
