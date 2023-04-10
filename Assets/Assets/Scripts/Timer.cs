using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    Image timerBar;
    public float maxTime = 15f;
    float timeLeft;

    bool runTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(runTimer == true){
            if(timeLeft > 0){
                timeLeft -= Time.deltaTime;
                timerBar.fillAmount = timeLeft / maxTime;
            }else{
                ChangeRunTimer(false);
                FindObjectOfType<GameManager>().IncreaseError();
                FindObjectOfType<FruitList>().ResetFruitList();
                FindObjectOfType<CustomerSwitch>().SwitchSprite();
            }
        }
        
    }

    public void ResetTimer(){
        timeLeft = maxTime;
    }

    public void ChangeRunTimer(bool change){
        runTimer = change;
    }
}
