using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame() 
    {
        //Change to the game scene
        SceneManager.LoadScene("Game");
    }
}
