using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class customerCounterScript : MonoBehaviour
{
    public static customerCounterScript instance;
    public TextMeshProUGUI text;
    public int amount;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

   public void ChangeAmount(int num)
    {
        amount += num;
        text.text = amount.ToString();
       
    }

    public void resetAmount()
    {
        amount = 0;
        text.text = "0";
    }
}
