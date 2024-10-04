using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagDropScript : MonoBehaviour
{
    //[SerializeField] private Collider floorDetectObj;
    public GameObject splashPS;
    public float fallingTime;
    MeshCollider meshCol;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshCol = GetComponent<MeshCollider>();
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
            Instantiate(splashPS, transform.position, transform.rotation);
        }
    }
}
