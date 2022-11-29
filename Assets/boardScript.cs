using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class boardScript : MonoBehaviour
{
    private bool t = false;
    private bool hasShownText = false;
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
            if (!hasShownText) {
                KillText.instance.show("Long Press P To Cut Vegetable", 2);
                hasShownText = true;
            }
            
           if(VegetableCounterScript.instance.amount > 0 && keyPress()){
               int amount = VegetableCounterScript.instance.amount;
               VegetableCounterScript.instance.ChangeAmount(-amount);
               lettuceCounterScript.instance.ChangeAmount(amount);
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
           // print("hold key");
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
