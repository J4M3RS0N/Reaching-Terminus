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

    [Header("Audio")]
    private AudioSource geyserAudio;
    [SerializeField] private AudioSource plumeAudio;
    [SerializeField] private AudioClip endingSound;

    // Start is called before the first frame update
    void Start()
    {
        geyserAudio = GetComponent<AudioSource>();

        //geyserDamageObj.SetActive(false);
        geyserDamageObj.transform.Rotate(180.0f, 0.0f, 0.0f);
        geyserWarningObj.SetActive(false);

        plumeAudio.enabled = false;

        StartCoroutine(SetOffGeyser());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private IEnumerator SetOffGeyser()
    {
        fireOffFloat = Random.Range(1.0f, 5.0f);

        geyserWarningObj.SetActive(true);

        yield return new WaitForSeconds(fireOffFloat);

        //geyserDamageObj.SetActive(true);
        geyserDamageObj.transform.Rotate(0.0f, 0.0f, 0.0f);

        plumeAudio.enabled = true;

        yield return new WaitForSeconds(firingTime);

        //geyserDamageObj.SetActive(false);
        geyserDamageObj.transform.Rotate(180.0f, 0.0f, 0.0f);
        geyserWarningObj.SetActive(false);

        //geyserAudio.PlayOneShot(endingSound);
        plumeAudio.enabled = false;

        StartCoroutine(SetOffGeyser());

    }
}

