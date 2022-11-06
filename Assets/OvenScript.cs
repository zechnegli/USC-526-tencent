using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class OvenScript : MonoBehaviour
{

    private bool t = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            t = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        t = false;
    }

    // Update is called once per frame
    [Obsolete]
    void Update()
    {
        if(t){
           if(Input.GetKeyDown(KeyCode.H)){
               int amount = BurgerCounterScript.instance.amount;
               BurgerCounterScript.instance.ChangeAmount(-amount);
               steamingBurgerCounterScript.instance.ChangeAmount(amount);
           }
            
        }
    }
}
