using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BurgerCounterScript : MonoBehaviour
{
   public static BurgerCounterScript instance;
   public TextMeshProUGUI text;
   public int amount;
   public int addnum;

    // Start is called before the first frame update
    void Start()
    {
         if(instance == null){
            instance = this;
         }
    }

    public void ChangeAmount(int num){
        //int amount = int.Parse(text.text);
        amount += num;
        text.text =  amount.ToString();
     //   KillText.instance.ChangeAmount("buger: " + amount.ToString());
    }

    public void resetAmount()
    {
        text.text = "0";
        amount = 0;
    }

    public void killbouns()
    {
        amount += 1;
        text.text = amount.ToString();
    }

}



