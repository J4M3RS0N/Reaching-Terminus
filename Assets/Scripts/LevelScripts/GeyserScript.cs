using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserScript : MonoBehaviour
{
    //Random Seed
    private float fireOffFloat;
    public float firingTime = 2.0f;
    public GameObject geyserDamageObj;
    public GameObject geyserWarningObj;

    // Start is called before the first frame update
    void Start()
    {
        geyserDamageObj.SetActive(false);
        geyserWarningObj.SetActive(false);

        StartCoroutine(SetOffGeyser());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SetOffGeyser()
    {
        fireOffFloat = Random.Range(1.0f, 5.0f);

        // turn on geyser collider + PS and SFX

        //yield return new WaitForSeconds(fireOffFloat);

        geyserWarningObj.SetActive(true);

        yield return new WaitForSeconds(fireOffFloat);

        geyserDamageObj.SetActive(true);

        yield return new WaitForSeconds(firingTime);

        geyserDamageObj.SetActive(false);
        geyserWarningObj.SetActive(false);

        StartCoroutine(SetOffGeyser());

    }
}

