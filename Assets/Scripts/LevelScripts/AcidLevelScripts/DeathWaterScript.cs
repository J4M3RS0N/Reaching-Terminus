using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathWaterScript : MonoBehaviour
{
    //GameManager current;

    // Start is called before the first frame update
    void Start()
    {
        //current = GetComponent<GameManager>();
    }


    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Died");
            SceneManager.LoadScene("Fail Scene");
        }
    }

}
