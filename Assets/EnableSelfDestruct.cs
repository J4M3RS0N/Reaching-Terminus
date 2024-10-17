using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSelfDestruct : MonoBehaviour
{
    [SerializeField] private ToastCollector fuel;
    [SerializeField] private CoolantCollector coolant;
    [SerializeField] private GameObject selfDestruct;

    // Update is called once per frame
    void Update()
    {
        if(fuel.currentHealth == 0 && coolant.currentHealth == 0 || Input.GetKey(KeyCode.X))
        {
            selfDestruct.SetActive(true);
        }
        else
        {
            selfDestruct.SetActive(false);
        }
    }
}
