using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinCounterScript : MonoBehaviour
{
    public static CoinCounterScript instance;
    public TextMeshProUGUI text;
    public int amount;
   // [SerializeField] TMP_Text coinCollectSucceed;

    // Start is called before the first frame update
    void Start()
    {
        //amount = int.Parse(text.text);
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

