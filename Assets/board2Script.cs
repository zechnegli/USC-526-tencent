using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class board2Script : MonoBehaviour
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
           if(Input.GetKeyDown(KeyCode.C)){
            Debug.Log("bread cut ");
               int amount = BreadCounterScript.instance.amount;
               Debug.Log("bread amount is " + amount);
               BreadCounterScript.instance.ChangeAmount(-amount);
               breadSliceCounterScript.instance.ChangeAmount(amount);
                Debug.Log("bread slice amount is " + breadSliceCounterScript.instance.amount);
           }
            
        }
    }
}
