using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    //Text displayed on canvas
    public TextMeshProUGUI scoreText;

    /***
    Update is called every frame, if the MonoBehaviour is enabled.
    ***/
    void Update(){   
        float score = PlayerPrefs.GetInt("Score");
        string final = "Score : " + score.ToString("0");
        scoreText.SetText(final);
    }
}