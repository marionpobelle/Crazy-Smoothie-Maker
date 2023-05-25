using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelBehavior : MonoBehaviour
{

    public int result = -1;
    private float finalAngle;

    int amountOfSmoothieMade = 0;


    public float minRotationSpeed = 1f;
    public float maxRotationSpeed = 8f;
    private float rotationSpeed;

    float intervalTimeSpeed = 0;
    float timerSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        amountOfSmoothieMade = FindObjectOfType<GameManager>().GetAmountOfSmoothie();
        rotationSpeed = Random.Range(1f, 2f);
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown("space") && FindObjectOfType<FruitList>().GetMaxSlotAttained() == false){
            finalAngle = transform.eulerAngles.z;
            Debug.Log(finalAngle);
            if(finalAngle > 330 && finalAngle <= 360 || finalAngle >= 0 && finalAngle < 30) result = 0;
            else if(finalAngle > 30 && finalAngle <= 90) result = 1;
            else if(finalAngle > 90 && finalAngle <= 150) result = 2;
            else if(finalAngle > 150 && finalAngle <= 220) result = 3;
            else if(finalAngle > 220 && finalAngle <= 280) result = 4;
            else if(finalAngle > 280 && finalAngle <= 330) result = 5;
            Debug.Log(result);
            FindObjectOfType<FruitList>().UpdateFruitList();
        }

    }

    void FixedUpdate(){
        if(intervalTimeSpeed == 0){
            intervalTimeSpeed = Random.Range(2f, 8f);
        }
        timerSpeed += Time.deltaTime;
        if(timerSpeed >= intervalTimeSpeed){
            rotationSpeed = Random.Range(minRotationSpeed,maxRotationSpeed);
            FindObjectOfType<AudioManager>().PlayOneShot("SpeedWheel");
            timerSpeed = 0;
            intervalTimeSpeed = 0;
        }
        transform.Rotate(0, 0, rotationSpeed);
    }

    public float GetRotationSpeed(){
        return rotationSpeed;
    }

    public void SetRotationSpeed(float newSpeed){
        rotationSpeed = newSpeed;
    }

    public int GetResult(){
        return result;
    }
    
}
