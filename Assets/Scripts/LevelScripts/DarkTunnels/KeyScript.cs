using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private GameObject doorButton;
    //public bool keyBool;

    // Start is called before the first frame update
    void Start()
    {
        //keyBool = false;
        doorButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeyFunction()
    {
        //keyBool = true;
        doorButton.SetActive(true);
        DestroyKey();
    }

    private void DestroyKey()
    {
        Destroy(this.gameObject);
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
