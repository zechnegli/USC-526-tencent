using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class steakCounterScript : MonoBehaviour
{
    public static steakCounterScript instance;
   public TextMeshProUGUI text;
   public int amount;

    // Start is called before the first frame update
    void Start()
    {
  //     amount = int.Parse(text.text);
        if(instance == null){
            instance = this;
         }
    }

    public void ChangeAmount(int num){
      //  int amount = int.Parse(text.text);
        amount += num;
        text.text =  amount.ToString();
    }

    public void resetAmount()
    {
        text.text = "0";
        amount = 0;
    }
}
