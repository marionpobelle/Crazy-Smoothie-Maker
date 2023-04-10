using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelBehavior : MonoBehaviour
{

    public int result = -1;
    private float finalAngle;

    int amountOfSmoothieMade = 0;

    // Start is called before the first frame update
    void Start()
    {
        amountOfSmoothieMade = FindObjectOfType<GameManager>().GetAmountOfSmoothie();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown("z") && FindObjectOfType<FruitList>().GetMaxSlotAttained() == false){
            finalAngle = transform.eulerAngles.z;
            Debug.Log(finalAngle);
            if(finalAngle > 330 && finalAngle < 360 || finalAngle > 0 && finalAngle < 30) result = 0;
            else if(finalAngle > 30 && finalAngle < 90) result = 1;
            else if(finalAngle > 90 && finalAngle < 150) result = 2;
            else if(finalAngle > 150 && finalAngle < 220) result = 3;
            else if(finalAngle > 220 && finalAngle < 280) result = 4;
            else if(finalAngle > 280 && finalAngle < 330) result = 5;
            Debug.Log(result);
            FindObjectOfType<FruitList>().UpdateFruitList();
        }

    }

    void FixedUpdate(){
        amountOfSmoothieMade = FindObjectOfType<GameManager>().GetAmountOfSmoothie();
        if(amountOfSmoothieMade >= 5 && amountOfSmoothieMade < 10){
            transform.Rotate(0, 0, 1.2f);
            FindObjectOfType<AudioManager>().PlayOneShot("SpeedWheel");
        } 
        else if(amountOfSmoothieMade >= 10){
            transform.Rotate(0, 0, 1.5f);
            FindObjectOfType<AudioManager>().PlayOneShot("SpeedWheel");
        } 
        else transform.Rotate(0, 0, 1f);
    }

    public int GetResult(){
        return result;
    }
    
}
