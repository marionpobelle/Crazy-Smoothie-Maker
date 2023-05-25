using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score = 0;

    int errors = 0;

    int maxErrors = 3;

    int amountOfSmoothieMade = 0;

    void Awake()
    {
        GameObject.Find("MixButton").GetComponent<Button>().interactable = false;
        GameObject.Find("RefreshButton").GetComponent<Button>().interactable = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Serving_smoothie");
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if(errors == maxErrors) LoadLosingScreen();
    }

    public void IncreaseError(){
        errors++;
    }

    public void IncreaseScore(){
        score+=5;
    }

    void LoadLosingScreen(){
        Debug.Log("You lost !");
        amountOfSmoothieMade = 0;
        SetScore();
        SceneManager.LoadScene("LosingScreen");
    }

    /***
    Set current score in PlayerPrefs.
    ***/
    public void SetScore(){
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    public int GetErrors(){
        return errors;
    }

    public void IncreaseSmoothies(){
        amountOfSmoothieMade+= 1;
    }

    public int GetAmountOfSmoothie(){
        return amountOfSmoothieMade;
    }
}
