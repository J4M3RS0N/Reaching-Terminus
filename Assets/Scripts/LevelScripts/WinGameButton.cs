using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameButton : MonoBehaviour
{
    public void WinGame()
    {
       SceneManager.LoadScene("WinScene");
    }
}
