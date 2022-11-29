using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Customer_level4_script : MonoBehaviour
{
    
    public GameObject meal;
    //public Sprite[] sprites;
    //private int oldSprite;
    //private int newSprite;
    //private List<int> availableSprites = new List<int>();
    //public GameObject[] food;
    private bool t = false;

    /*void Start() {
  oldSprite = 0;
  for (int i = 0; i < sprites.Length; i++) {
   availableSprites.Add(i);
  }
  GameObject gameObject = Instantiate(food[Random.Range(0, sprites.Length)]);
 }*/
    public static Customer_level4_script instance;
    public int prevHighlightIndex = 0;
    public int chooseCustomer = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        if (other.gameObject.CompareTag("Player"))
        {
//            dialog.SetActive(true);
//            Debug.Log(BurgerCounterScript.instance.amount);
//            Debug.Log(CoinCounterScript.instance.amount);
            t = true;


            
            //GameObject.Find("RandomHandler").GetComponent<RandomHandler>().SpawnNewMaterial();
        }
        /*availableSprites.Remove(oldSprite);
  newSprite = availableSprites[Random.Range(0,availableSprites.Count)];
  GetComponent<SpriteRenderer>().sprite = sprites[newSprite];
  
  availableSprites.Add(oldSprite);
  oldSprite = newSprite;*/
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        t = false;
        OrdersController.instance.deHighlightOrder(0);
        OrdersController.instance.deHighlightOrder(1);
        OrdersController.instance.deHighlightOrder(2);
    }
    
    void Start(){
        if(instance == null){
            instance = this;
         }
    }
    [Obsolete]
    void Update(){
        
        if(t){
          //  print(chooseCustomer);
            if(this.gameObject.name == "customer1" && chooseCustomer == 0){
                OrdersController.instance.highlightOrder(0);
//                KillText.instance.show("Press C To Choose Serveing This Customer", 2);
//                if (Input.GetKeyDown(KeyCode.C))
//                {
//                    if (prevHighlightIndex != 0) {
//                        OrdersController.instance.deHighlightOrder(prevHighlightIndex);
//                    }
//                    OrdersController.instance.highlightOrderIndex = 0;
//                    prevHighlightIndex = 0;
//                    TelescopeDoor.instance.chooseCustomer = 1;
//                    
//                    
                        
////                    GameObject player_transform = GameObject.Find("Player");
////                    player_transform.transform.position = new Vector3(27, 0, 0);
//                }
                
                //                dialog.SetActive(false);           
                if (OrdersController.instance.checkIfIngredientsCompleted(0) && keyPress()) { 
                        //MenuIngredientsController.instance.checkIngredients();
                        OrdersController.instance.reduceIngredients(0);
                        OrdersController.instance.highlightOrderIndex = -1;
                        // OrdersController.instance.deHighlightOrder(prevHighlightIndex);
                        chooseCustomer = 0;
                        //CoinCounterScript.instance.ChangeAmount(40);
                        OrdersController.instance.hideOrder(0,1);
                        customerCounterScript.instance.ChangeAmount(1);
                        this.gameObject.transform.localPosition = new Vector3(-10,10, 0);
                        this.meal.transform.localPosition = new Vector3(-10,10, 0);
                         OrdersController.instance.markAsFinished(0);
                 //       OrdersController.instance.hideOrder(0,0);
                        // this.gameObject.transform.localPosition = new Vector3(-10,-10, 0);
                        // this.dialog.transform.localPosition = new Vector3(-10,-10, 0);
                        Debug.Log("serve customer1");
                    }
            }
            if(this.gameObject.name == "customer2" && chooseCustomer == 0){
                OrdersController.instance.highlightOrder(1);
//                KillText.instance.show("Press C To Choose Serveing This Customer", 2);
//                if (Input.GetKeyDown(KeyCode.C))
//                {
//                    if (prevHighlightIndex != 1) {
//                        OrdersController.instance.deHighlightOrder(prevHighlightIndex);
//                    }
//                    OrdersController.instance.highlightOrderIndex = 1;
//                    prevHighlightIndex = 1;
//                    TelescopeDoor.instance.chooseCustomer = 1;
////                    GameObject player_transform = GameObject.Find("Player");
////                    player_transform.transform.position = new Vector3(66, 0, 0);
//                }
                if (OrdersController.instance.checkIfIngredientsCompleted(1) && keyPress()){
                    //MenuIngredientsController.instance.checkIngredients();
                    OrdersController.instance.reduceIngredients(1);
                    OrdersController.instance.highlightOrderIndex = -1;
                     
                    chooseCustomer = 0;
                    //CoinCounterScript.instance.ChangeAmount(40);
                    OrdersController.instance.hideOrder(1,1);
                     customerCounterScript.instance.ChangeAmount(1);
                     this.gameObject.transform.localPosition = new Vector3(-10,10, 0);
                        this.meal.transform.localPosition = new Vector3(-10,10, 0);
                        OrdersController.instance.markAsFinished(1);
                   //      OrdersController.instance.hideOrder(1,0);
                    // this.gameObject.transform.localPosition = new Vector3(-10,-10, 0);
                    // this.dialog.transform.localPosition = new Vector3(-10,-10, 0);
                    Debug.Log("serve customer2");
                }
                    
            }
            if(this.gameObject.name == "customer3" && chooseCustomer == 0){
                OrdersController.instance.highlightOrder(2);
//                KillText.instance.show("Press C To Choose Serveing This Customer", 2);
//                if (Input.GetKeyDown(KeyCode.C))
//                {
//                    if (prevHighlightIndex != 2) {
//                        OrdersController.instance.deHighlightOrder(prevHighlightIndex);
//                    }
//                    OrdersController.instance.highlightOrderIndex = 2;
//                    prevHighlightIndex = 2;
//                    TelescopeDoor.instance.chooseCustomer = 3;
////                    GameObject player_transform = GameObject.Find("Player");
////                    player_transform.transform.position = new Vector3(98, 5, 0);
//                }
                if (OrdersController.instance.checkIfIngredientsCompleted(2) && keyPress()){
                //MenuIngredientsController.instance.checkIngredients();
                //CoinCounterScript.instance.ChangeAmount(40);
                    OrdersController.instance.reduceIngredients(2);
                    OrdersController.instance.highlightOrderIndex = -1;
                    // OrdersController.instance.deHighlightOrder(prevHighlightIndex);
                    chooseCustomer = 0;
                    OrdersController.instance.hideOrder(2,1);
                    customerCounterScript.instance.ChangeAmount(1);

                    this.gameObject.transform.localPosition = new Vector3(-10,10, 0);
                    this.meal.transform.localPosition = new Vector3(-10,10, 0);
                    OrdersController.instance.markAsFinished(2);
                  //   OrdersController.instance.hideOrder(2,0);
                    // this.gameObject.transform.localPosition = new Vector3(-10,-10, 0);
                    // this.dialog.transform.localPosition = new Vector3(-10,-10, 0);
                    Debug.Log("serve customer3");
                }
            }
            if(this.gameObject.tag == "door1"){
                KillText.instance.show("Press E Return To Cooking Area", 2);
                if (Input.GetKeyDown(KeyCode.E))
                    {

                        // OrdersController.instance.highlightOrderIndex = -1;
                        GameObject player_transform = GameObject.Find("Player");
                        player_transform.transform.position = new Vector3(6, 0, 0);
                    }
            }
            /*
            if(this.gameObject.name == "customer4"){
                OrdersController.instance.highlightOrder(3);
                if (Input.GetKeyDown(KeyCode.P)) { 
                        if(OrdersController.instance.checkIfIngredientsCompleted(3)){
                        //MenuIngredientsController.instance.checkIngredients();
                        //CoinCounterScript.instance.ChangeAmount(40);
                            OrdersController.instance.hideOrder(3,1);
                            // this.gameObject.transform.localPosition = new Vector3(-10,-10, 0);
                            // this.dialog.transform.localPosition = new Vector3(-10,-10, 0);
                            Debug.Log("serve customer4");
                        }
                    }
            }*/
            /* if(this.gameObject.name == "customer5"){
                if(steamingBurgerCounterScript.instance.amount >= 4){
    //                dialog.SetActive(false);           
                    if (Input.GetKeyDown(KeyCode.P)) { 
                        steamingBurgerCounterScript.instance.ChangeAmount(-4);
                        CoinCounterScript.instance.ChangeAmount(80);
                        this.gameObject.transform.localPosition = new Vector3(-10,-10, 0);
                        this.dialog.transform.localPosition = new Vector3(-10,-10, 0);
                        Debug.Log("serve customer5");
                    }
                }
            }
            */

        }
        
        // 
        
    
    }
    
     public bool keyPress() {  
        if (Input.GetKeyDown (KeyCode.P))
        {
           // print("press key");
            ProgressBar.instance.displayProgressBar();
            //Touch Begin - True when the finger touches the screen
            //Play animation for chicken squat
        }
        else if(Input.GetKey (KeyCode.P))
        {
          //  print("hold key");
            ProgressBar.instance.incrementProgress(0.1f);
            //Touch Continued - True when the finger is still touching the screen
            if (ProgressBar.instance.checkIfSliderToFull()) {
                ProgressBar.instance.hideProgressBar();
                return true;
            }
        }
        else if(Input.GetKeyUp (KeyCode.P))
        {
          //  print("release key");
            ProgressBar.instance.hideProgressBar();
            //Touch End - True when the finger is lifted from the screen
            //Play animation for chicken jump
        }
        return false;
     }

}
