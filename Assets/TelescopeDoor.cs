using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Random = System.Random;

public class TelescopeDoor : MonoBehaviour
{
    public static TelescopeDoor instance;
    public int chooseCustomer = 0;
    private bool t = false; 
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
         }
    }
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
    // Update is called once per frame
    void Update()
    {
        if(t){
//             if(chooseCustomer != 0){
                KillText.instance.show("Press E To Enter The Market", 2);
                if (Input.GetKeyDown(KeyCode.E))
                    {
                        GameObject player_transform = GameObject.Find("Player");
                        Random random = new Random();
                        int door = random.Next(0, 3);
                        if (door == 0) {
                            player_transform.transform.position = new Vector3(98, 5, 0);
                        } else if (door == 1) {
                            player_transform.transform.position = new Vector3(66, 0, 0);
                        } else {
                            player_transform.transform.position = new Vector3(27, 0, 0);
                        }                   
                        
                    }
                }
//            else{
//                KillText.instance.show("Please Back To Choose A Customer", 2);
//            }
            
//        }
        
    }
}
