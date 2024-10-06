using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private EndGameScript endGame;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            slider.value += Time.deltaTime;

            //play some warning sounds and flashing red lights

            if(slider.value >= 5f)
            {
                //begin self destruct sequence
                StartCoroutine(SelfDestructSequence());
            }
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            slider.value = 0;
        }
    }

    private IEnumerator SelfDestructSequence()
    {
        slider.value = 5f;
        //play explosions and kill player
        yield return new WaitForSeconds(2);

        endGame.PlayerDied();
        yield return null;
    }
}
