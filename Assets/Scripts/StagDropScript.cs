using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagDropScript : MonoBehaviour
{
    //[SerializeField] private Collider floorDetectObj;
    public float fallingTime;
    MeshCollider meshCol;
    Rigidbody rb;
    AudioSource stagAudio;
    [SerializeField] private AudioClip splashSFX;
    [SerializeField] private GameObject replacementStag;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshCol = GetComponent<MeshCollider>();
        stagAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DetatchStag()
    {
        StartCoroutine(DropStag());
    }

    public IEnumerator DropStag()
    {
        rb.isKinematic = false;
        meshCol.enabled = false;
        yield return new WaitForSeconds(fallingTime);
        rb.isKinematic = true;
        meshCol.enabled = true;
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Tar")
        {
            stagAudio.PlayOneShot(splashSFX);
            replacementStag.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
