using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechAbilityPanelToggle : MonoBehaviour
{
    [SerializeField] private GameObject abilityPanel;
    [SerializeField] private EnterMechDemo enterMech;
    [SerializeField] private GameObject ignitionPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //toggling active state of ability panels
        if(enterMech.playerInMech == true && Input.GetKeyDown(KeyCode.Tab))
        {
            abilityPanel.SetActive(true);
        }

        if(enterMech.playerInMech == true && Input.GetKeyUp(KeyCode.Tab))
        {
            abilityPanel.SetActive(false);
        }

        //toggle Ignition tutorial
        if (enterMech.playerInMech == true && Input.GetKeyDown(KeyCode.C))
        {
            if(GameManager.current.mechTutorialActive == true)
            {
                ignitionPanel.SetActive(false);
            }
            else
            {
                return;
            }
        }
    }
}
