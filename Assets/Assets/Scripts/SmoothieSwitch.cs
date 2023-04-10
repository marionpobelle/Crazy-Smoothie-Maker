using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothieSwitch : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer smoothie;

    [SerializeField]
    private Sprite[] smoothieSprites;

    public void SwitchSmoothie(){
        int randomSmoothie = UnityEngine.Random.Range(0,6);
        if(randomSmoothie == 0)  smoothie.sprite = smoothieSprites[0];
        else if(randomSmoothie == 1)  smoothie.sprite = smoothieSprites[1];
        else if(randomSmoothie == 2)  smoothie.sprite = smoothieSprites[2];
        else if(randomSmoothie == 3)  smoothie.sprite = smoothieSprites[3];
        else if(randomSmoothie == 4)  smoothie.sprite = smoothieSprites[4];
        else smoothie.sprite = smoothieSprites[5];
    }
}
