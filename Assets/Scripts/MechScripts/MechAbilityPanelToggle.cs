using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechAbilityPanelToggle : MonoBehaviour
{
    [SerializeField] private GameObject abilityPanel;
    [SerializeField] private EnterMechDemo enterMech;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enterMech.playerInMech == true && Input.GetKeyDown(KeyCode.Tab))
        {
            abilityPanel.SetActive(true);
        }

        if(enterMech.playerInMech == true && Input.GetKeyUp(KeyCode.Tab))
        {
            abilityPanel.SetActive(false);
        }
    }
}
