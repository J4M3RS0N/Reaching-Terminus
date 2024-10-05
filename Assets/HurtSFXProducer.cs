using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSFXProducer : MonoBehaviour
{
    public List<AudioClip> damageSounds = new List<AudioClip>();
    AudioSource hurtAudio;

    public void Awake()
    {
        hurtAudio = GetComponent<AudioSource>();

        StartCoroutine(DamageSounds());
    }

    private IEnumerator DamageSounds()
    {
        while (true)
        {
            //play a sound selected randomly from the list of damaged sounds
            AudioClip hurtSound = damageSounds[Random.Range(0, damageSounds.Count)];
            hurtAudio.PlayOneShot(hurtSound);

            yield return new WaitForSeconds(2);
        }
    }
}
