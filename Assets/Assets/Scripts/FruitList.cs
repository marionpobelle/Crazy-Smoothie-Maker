using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FruitList : MonoBehaviour
{

    [SerializeField, Tooltip("The 6 fruits ordered correctly")]
    //0 banana
    //1 blueberry
    //2 orange
    //3 kiwi
    //4 grape
    //5 strawberry
    private Sprite[] fruitSprites;

    //Stuff relative to the mix
    int nextAvailableSlot = 0;
    int maxSlot = 3;

    bool maxSlotAttained = false;

    [SerializeField]
    private SpriteRenderer[] slotsCooking;

    int[] mixRefFruit = new int[] {-1, -1, -1};

    //Stuff relative to the order
    [SerializeField]
    private SpriteRenderer[] slotsOrder;

    int[] orderRefFruit = new int[] {-1, -1, -1};

    bool wrongOrder = false;

    public void UpdateFruitList(){
        if(maxSlotAttained == false){
            SyncSprite(slotsCooking[nextAvailableSlot], FindObjectOfType<WheelBehavior>().GetResult());
            mixRefFruit[nextAvailableSlot] = FindObjectOfType<WheelBehavior>().GetResult();
            nextAvailableSlot++;

            int randomSound = UnityEngine.Random.Range(0,3);
            if(randomSound == 0) FindObjectOfType<AudioManager>().PlayOneShot("Fruit1");
            if(randomSound == 1) FindObjectOfType<AudioManager>().PlayOneShot("Fruit2");
            if(randomSound == 2) FindObjectOfType<AudioManager>().PlayOneShot("Fruit3");
            if(nextAvailableSlot == maxSlot) maxSlotAttained = true;
        }
    }

    public void ResetFruitList(){
        nextAvailableSlot = 0;
        slotsCooking[0].sprite = null;
        slotsCooking[1].sprite = null;
        slotsCooking[2].sprite = null;
        maxSlotAttained = false;
    }

    /***
    We give the slot that needs to be filled and the wheel result to the function
    ***/
    public void SyncSprite(SpriteRenderer slot, int result){
        if(result == 0) slot.sprite = fruitSprites[0];
        else if (result == 1) slot.sprite = fruitSprites[1];
        else if (result == 2) slot.sprite = fruitSprites[2];
        else if (result == 3) slot.sprite = fruitSprites[3];
        else if (result == 4) slot.sprite = fruitSprites[4];
        else if (result == 5) slot.sprite = fruitSprites[5];
    }

    public bool GetMaxSlotAttained(){
        return maxSlotAttained;
    }

    public void UpdateFruitOrder(){
        SyncSpriteOrder(slotsOrder, orderRefFruit);
        FindObjectOfType<GameManager>().IncreaseSmoothies();
    }

    public void SyncSpriteOrder(SpriteRenderer[] slot, int[] refFruit){
        int randomSlot1 = UnityEngine.Random.Range(0,6);
        int randomSlot2 = UnityEngine.Random.Range(0,6);
        int randomSlot3 = UnityEngine.Random.Range(0,6);
        while(randomSlot2 == randomSlot1) randomSlot2 = UnityEngine.Random.Range(0,6);
        while((randomSlot3 == randomSlot1) || (randomSlot3 == randomSlot2)) randomSlot3 = UnityEngine.Random.Range(0,6);
        slot[0].sprite = fruitSprites[randomSlot1];
        refFruit[0] = randomSlot1;
        slot[1].sprite = fruitSprites[randomSlot2];
        refFruit[1] = randomSlot2;
        slot[2].sprite = fruitSprites[randomSlot3];
        refFruit[2] = randomSlot3;
    }

    public void CheckEqualOrder(){
        FindObjectOfType<Timer>().ChangeRunTimer(false);
        bool OrderEqualMix = true;
        Array.Sort(mixRefFruit);
        Array.Sort(orderRefFruit);
        for(int i=0; i<mixRefFruit.Length; i++){
            if(!mixRefFruit[i].Equals(orderRefFruit[i])){
                Debug.Log(i + " for mix is " + mixRefFruit[i]);
                Debug.Log(i + " for order is " + orderRefFruit[i]);
                
                Debug.Log(OrderEqualMix);
                OrderEqualMix = false;
                Debug.Log(OrderEqualMix);
            }
        }
        if(OrderEqualMix == false){
            Debug.Log("Wrong order !");
            FindObjectOfType<GameManager>().IncreaseError();
            FindObjectOfType<AudioManager>().PlayOneShot("Error");
            FindObjectOfType<OrderStatus>().SwitchSprite(1);

            wrongOrder = true;
            
        }else{
            Debug.Log("Right order !");
            FindObjectOfType<GameManager>().IncreaseScore();
            FindObjectOfType<AudioManager>().PlayOneShot("Cash");
            FindObjectOfType<OrderStatus>().SwitchSprite(0);

            wrongOrder = false;
        }
    }

    public bool GetWrongOrder(){
        return wrongOrder;
    }
}
