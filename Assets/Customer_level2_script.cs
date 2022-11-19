using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Customer_level2_script : MonoBehaviour
{
    public GameObject dialog;
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
            if(this.gameObject.name == "customer1"){
                if(steamingBurgerCounterScript.instance.amount >= 2){
    //                dialog.SetActive(false);           
                    if (Input.GetKeyDown(KeyCode.P)) { 
                        steamingBurgerCounterScript.instance.ChangeAmount(-2);
                     //   CoinCounterScript.instance.ChangeAmount(40);
                     customerCounterScript.instance.ChangeAmount(1);
                        this.gameObject.transform.localPosition = new Vector3(-10,-10, 0);
                        this.dialog.transform.localPosition = new Vector3(-10,-10, 0);
                        Debug.Log("serve customer1");
                    }
                }
            }
            if(this.gameObject.name == "customer2"){
                if(steamingBurgerCounterScript.instance.amount >= 3){
    //                dialog.SetActive(false);           
                    if (Input.GetKeyDown(KeyCode.P)) { 
                        steamingBurgerCounterScript.instance.ChangeAmount(-3);
                      //  CoinCounterScript.instance.ChangeAmount(60);
                      customerCounterScript.instance.ChangeAmount(1);
                        this.gameObject.transform.localPosition = new Vector3(-10,-10, 0);
                        this.dialog.transform.localPosition = new Vector3(-10,-10, 0);
                        Debug.Log("serve customer2");
                    }
                }
            }
            if(this.gameObject.name == "customer3"){
                if(steamingBurgerCounterScript.instance.amount >= 4){
    //                dialog.SetActive(false);           
                    if (Input.GetKeyDown(KeyCode.P)) { 
                        steamingBurgerCounterScript.instance.ChangeAmount(-4);
                      //  CoinCounterScript.instance.ChangeAmount(80);
                      customerCounterScript.instance.ChangeAmount(1);
                        this.gameObject.transform.localPosition = new Vector3(-10,-10, 0);
                        this.dialog.transform.localPosition = new Vector3(-10,-10, 0);
                        Debug.Log("serve customer3");
                    }
                }
            }
            if(this.gameObject.name == "customer4"){
                if(steamingBurgerCounterScript.instance.amount >= 2){
    //                dialog.SetActive(false);           
                    if (Input.GetKeyDown(KeyCode.P)) { 
                        steamingBurgerCounterScript.instance.ChangeAmount(-2);
                      //  CoinCounterScript.instance.ChangeAmount(40);
                      customerCounterScript.instance.ChangeAmount(1);
                        this.gameObject.transform.localPosition = new Vector3(-10,-10, 0);
                        this.dialog.transform.localPosition = new Vector3(-10,-10, 0);
                        Debug.Log("serve customer4");
                    }
                }
            }
            if(this.gameObject.name == "customer5"){
                if(steamingBurgerCounterScript.instance.amount >= 4){
    //                dialog.SetActive(false);           
                    if (Input.GetKeyDown(KeyCode.P)) { 
                        steamingBurgerCounterScript.instance.ChangeAmount(-4);
                       // CoinCounterScript.instance.ChangeAmount(80);
                       customerCounterScript.instance.ChangeAmount(1);
                        this.gameObject.transform.localPosition = new Vector3(-10,-10, 0);
                        this.dialog.transform.localPosition = new Vector3(-10,-10, 0);
                        Debug.Log("serve customer5");
                    }
                }
            }
            
        }
    
    }


}