using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void StartGame(){
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Game");
    }

    public void Quit(){
        FindObjectOfType<AudioManager>().Play("Button");
        Application.Quit();
    }

    public void MainMenu(){
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Menu");
    }
    
}
