using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedButtons : MonoBehaviour
{

    GameObject wheel;
    WheelBehavior wheelBehaviorScript;

    void Awake()    
    {
        wheel = GameObject.FindGameObjectWithTag("WheelTag");
        wheelBehaviorScript = wheel.GetComponent<WheelBehavior>();
    }
    public void DecreaseSpeedButton(){
        float newSpeed = wheelBehaviorScript.GetRotationSpeed();
        newSpeed -= 1f;
        if(newSpeed < wheelBehaviorScript.minRotationSpeed) return;
        else wheelBehaviorScript.SetRotationSpeed(newSpeed);
    }

    public void IncreaseSpeedButton(){
        float newSpeed = wheelBehaviorScript.GetRotationSpeed();
        newSpeed += 1f;
        if(newSpeed > wheelBehaviorScript.maxRotationSpeed) return;
        else wheelBehaviorScript.SetRotationSpeed(newSpeed);
    }
}
