using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.UI;
using TMPro;


// Use following command with inputMessage to show the message for 3 seconds:
// KillText.instance.ChangeAmount(string inputMeassge);
public class KillText : MonoBehaviour
{   public static KillText instance;
    public TextMeshProUGUI text;
    public int second = 3;
    public bool flag = false;
    public Image background;

    void Start(){
        if(instance == null){
            instance = this;
        }
        // ChangeAmount("MessageInput");
    }

     public void ChangeAmount(string inputMessage){
//        int amount = int.Parse(text.text);
        text.text =  inputMessage;
        second = 3;
        flag = true;
    }

    public void show(string inputMessage, int sec){
//        int amount = int.Parse(text.text);
        text.text =  inputMessage;
        second =sec;
        flag = true;
    }

    public void resetAmount()
    {
        text.text = "";
        flag = false;
        second = 3;
    }

    private float nexttime=1;
    // [Obsolete]
    public void Update(){
        if(flag){
            if(Time.time >= nexttime){
                second--;
                nexttime = Time.time + 1;
                if(second <= 0){
                    resetAmount();
                }
            }
            
            background.enabled = true;
        }else{
            text.text = "";
            background.enabled = false;
        }
        
    }
}
