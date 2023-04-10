using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderStatus : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer status;

    [SerializeField]
    private Sprite[] statusList;

    public void SwitchSprite(int eta){
        //0 for right order
        //1 for wrong order
        //the remaining for null
        if(eta == 0) status.sprite = statusList[0];
        else if(eta == 1) status.sprite = statusList[1];
        else status.sprite = null;
    }

}
