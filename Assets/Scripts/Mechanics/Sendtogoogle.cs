using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Sendtogoogle : MonoBehaviour
{


    //public static Sendtogoogle controller;
    [SerializeField]
    private string BASE_URL;
    
    //public static Sendtogoogle instance;
    //CoinCounterScript coins = new CoinCounterScript();
    //MeatCounterScript meats = new MeatCounterScript();
    //VegetableCounterScript veges = new VegetableCounterScript();
    //BreadCounterScript breads = new BreadCounterScript();

    IEnumerator Post(string meat, string vege,string bread,string coin)
    {
        Debug.Log("--Posting data--");
        WWWForm form = new WWWForm();
        form.AddField("entry.1788369545", meat);
        form.AddField("entry.668316900", vege);
        form.AddField("entry.986884399", bread);
        form.AddField("entry.829783135", coin);
        
        using (UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form))
        {
            Debug.Log("--Sending request--");
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Data upload complete");
            }
        }
           
    }

    public void Send()
    {
        try{
            int Meatamount = int.Parse(MeatCounterScript.instance.text.text);
            int Vegeamount = int.Parse(VegetableCounterScript.instance.text.text);
            int Breadamount = int.Parse(BreadCounterScript.instance.text.text);
            int Coinamount = int.Parse(CoinCounterScript.instance.text.text);
            Debug.Log("coinum: " + Coinamount);
            StartCoroutine(Post(Meatamount.ToString(),Vegeamount.ToString(), Breadamount.ToString(), Coinamount.ToString()));

        }catch{
        }


    }
    // Start is called before the first frame update
    void Awake()
    {
        BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSffA05txjN1blXZRZMb3LgZJywyDHVpGXMbgqGUu_zDGKIJuw/formResponse";
    }


}
