using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHangerDoors : MonoBehaviour
{
    Animator hangerAnimator;
    public GameObject doorButton;

    IEnumerator switchbuttonOff;

    // Start is called before the first frame update
    void Start()
    {
        hangerAnimator = GetComponent<Animator>();
        switchbuttonOff = SwitchButtonOff();
    }

    public void PlayDoorOpenAnim()
    {
        hangerAnimator.SetBool("OpenDoors", true);
        StartCoroutine(switchbuttonOff);
    }

    private IEnumerator SwitchButtonOff()
    {
        yield return new WaitForSeconds(1);

        doorButton.SetActive(false);
    }
}
