using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePanelScript : MonoBehaviour
{
    public static SavePanelScript losePanel;

    // Start is called before the first frame update
    void Start()
    {
        if (losePanel == null)
        {
            DontDestroyOnLoad(gameObject);
            losePanel = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
