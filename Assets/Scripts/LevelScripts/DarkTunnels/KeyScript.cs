using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public static KeyScript TunnelKey;

    [SerializeField] private GameObject doorButton;
    public bool keyBool;

    // Start is called before the first frame update
    void Start()
    {
        TunnelKey = this;

        //keyBool = false;
        doorButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeyFunction()
    {
        doorButton.SetActive(true);

        keyBool = true;

        StartCoroutine(DestroyKey());
    }

    public Transform GetTransform()
    {
        return transform;
    }

    private IEnumerator DestroyKey()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
