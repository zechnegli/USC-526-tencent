using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class CustomerScript : MonoBehaviour
{
    public GameObject dialog;
    public GameObject burger;
    //public Sprite[] sprites;
    //private int oldSprite;
    //private int newSprite;
    //private List<int> availableSprites = new List<int>();
    //public GameObject[] food;
    private bool t = false;
    private bool hasShownText = false;

    /*void Start() {
  oldSprite = 0;
  for (int i = 0; i < sprites.Length; i++) {
   availableSprites.Add(i);
  }
  GameObject gameObject = Instantiate(food[Random.Range(0, sprites.Length)]);
 }*/


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
    }
    
    void Start(){
    
    }
    [Obsolete]
    void Update(){
        if(t){
            if (!hasShownText) {
                KillText.instance.show("Press P to serve", 2);
                hasShownText = true;
            }
            
            if(this.gameObject.name == "customer1"){
                if(BurgerCounterScript.instance.amount >= 2 && keyPress()){
    //                dialog.SetActive(false);           
                        BurgerCounterScript.instance.ChangeAmount(-2);
                     //   CoinCounterScript.instance.ChangeAmount(40);
                     customerCounterScript.instance.ChangeAmount(1);
                        this.gameObject.transform.localPosition = new Vector3(-10,-10, 0);
                        this.dialog.transform.localPosition = new Vector3(-10,-10, 0);
                        this.burger.transform.localPosition = new Vector3(-10,-10, 0);
                    
                }
            }
            if(this.gameObject.name == "customer2"){
                if(BurgerCounterScript.instance.amount >= 3 && keyPress()){
    //                dialog.SetActive(false);           
                        BurgerCounterScript.instance.ChangeAmount(-3);
                       // CoinCounterScript.instance.ChangeAmount(60);
                       customerCounterScript.instance.ChangeAmount(1);
                        this.gameObject.transform.localPosition = new Vector3(-10,-10, 0);
                        this.dialog.transform.localPosition = new Vector3(-10,-10, 0);
                        this.burger.transform.localPosition = new Vector3(-10,-10, 0);
                }
            }
            if(this.gameObject.name == "customer3"){
                if(BurgerCounterScript.instance.amount >= 4 && keyPress()){
    //                dialog.SetActive(false);            
                        BurgerCounterScript.instance.ChangeAmount(-4);
                       // CoinCounterScript.instance.ChangeAmount(80);
                       customerCounterScript.instance.ChangeAmount(1);
                        this.gameObject.transform.localPosition = new Vector3(-10,-10, 0);
                        this.dialog.transform.localPosition = new Vector3(-10,-10, 0);
                        this.burger.transform.localPosition = new Vector3(-10,-10, 0);
                    
                }
            }
            if(this.gameObject.name == "customer4"){
                if(BurgerCounterScript.instance.amount >= 2 && keyPress()){
    //                dialog.SetActive(false);           
                        BurgerCounterScript.instance.ChangeAmount(-2);
                      //  CoinCounterScript.instance.ChangeAmount(40);
                      customerCounterScript.instance.ChangeAmount(1);
                        this.gameObject.transform.localPosition = new Vector3(-10,-10, 0);
                        this.dialog.transform.localPosition = new Vector3(-10,-10, 0);
                        this.burger.transform.localPosition = new Vector3(-10,-10, 0);
                    }
                
            }
            if(this.gameObject.name == "customer5"){
                if(BurgerCounterScript.instance.amount >= 4 && keyPress()){
    //                dialog.SetActive(false);           
                        BurgerCounterScript.instance.ChangeAmount(-4);
                      //  CoinCounterScript.instance.ChangeAmount(80);
                      customerCounterScript.instance.ChangeAmount(1);
                        this.gameObject.transform.localPosition = new Vector3(-10,-10, 0);
                        this.dialog.transform.localPosition = new Vector3(-10,-10, 0);
                        this.burger.transform.localPosition = new Vector3(-10,-10, 0);
                }
            }
            
        }
    
    }
    public bool keyPress() {  
        if (Input.GetKeyDown (KeyCode.P))
        {
          //  print("press key");
            ProgressBar.instance.displayProgressBar();
            //Touch Begin - True when the finger touches the screen
            //Play animation for chicken squat
        }
        else if(Input.GetKey (KeyCode.P))
        {
         //   print("hold key");
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