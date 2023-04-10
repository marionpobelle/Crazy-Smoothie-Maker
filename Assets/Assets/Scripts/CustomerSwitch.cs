using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSwitch : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer customer;

    [SerializeField]
    private Sprite[] customerSprites;

    [SerializeField]
    private Sprite[] angryCustomerSprites;

    bool firstCustomer = true;

    //0 = capybara
    //1 = red panda
    //2 = koala
    int customerID = 0;

    // Start is called before the first frame update
    void Start()
    {
        SwitchSprite();
        firstCustomer = false;
    }

    public void SwitchSprite(){
        if(firstCustomer == false){
            FindObjectOfType<SmoothieSwitch>().SwitchSmoothie();
            if(FindObjectOfType<FruitList>().GetWrongOrder() == true){

                if(customerID == 0)  customer.sprite = angryCustomerSprites[0];
                else if(customerID == 1)  customer.sprite = angryCustomerSprites[1];
                else if(customerID == 2)  customer.sprite = angryCustomerSprites[2];

                int randomSound = UnityEngine.Random.Range(0,3);
                if(randomSound == 0) FindObjectOfType<AudioManager>().PlayOneShot("Angry1");
                else if(randomSound == 1) FindObjectOfType<AudioManager>().PlayOneShot("Angry2");
                else FindObjectOfType<AudioManager>().PlayOneShot("Angry3");
            }

            else if(FindObjectOfType<FruitList>().GetWrongOrder() == false){
                int randomSound = UnityEngine.Random.Range(0,3);
                if(randomSound == 0) FindObjectOfType<AudioManager>().PlayOneShot("Happy1");
                else if(randomSound == 1) FindObjectOfType<AudioManager>().PlayOneShot("Happy2");
                else FindObjectOfType<AudioManager>().PlayOneShot("Happy3");
            }
        }
        
        StartCoroutine(WaitForClient());
        
    }


    IEnumerator WaitForClient(){
        //yield on a new YieldInstruction that waits for 3 seconds.
        yield return new WaitForSeconds(3);

        int randomCustomer = Random.Range(0,3);
        if(randomCustomer == 0){
            customer.sprite = customerSprites[0];
            customerID = 0;
        } 
        else if (randomCustomer == 1){
            customer.sprite = customerSprites[1];
            customerID = 1;
        } 
        else if(randomCustomer == 2){
            customer.sprite = customerSprites[2];
            customerID = 2;
        } 
        customer.GetComponent<Renderer>().enabled = true;
        FindObjectOfType<AudioManager>().Play("New_customer");

        FindObjectOfType<FruitList>().UpdateFruitOrder();
        FindObjectOfType<Timer>().ChangeRunTimer(true);
        FindObjectOfType<Timer>().ResetTimer();
        FindObjectOfType<OrderStatus>().SwitchSprite(2);
    }
}
