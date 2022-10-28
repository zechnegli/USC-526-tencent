using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Sendtogoogle_level : MonoBehaviour
{

    //public static Sendtogoogle_level controller;
    [SerializeField] private string BASE_URL;
    [SerializeField] private string level;


    IEnumerator Post(string burger, string level)
    {
        Debug.Log("--Posting data--");

        WWWForm form = new WWWForm();
        form.AddField("entry.366340186", level);
        form.AddField("entry.1890291882", burger);
        Debug.Log(BASE_URL);
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

    public void Send_burger()
    {
        try{
            int Burger_amount = int.Parse(BurgerCounterScript.instance.text.text);
            //level = currentLevel.instance.getLevel();
            Debug.Log("burger_amount: " + Burger_amount);
            Debug.Log("level：" + level);
            StartCoroutine(Post(Burger_amount.ToString(), level));

        }catch{
        }

    }

    //Start is called before the first frame update
    void Awake()
    {
        BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSeYfQqh0wdnVU8NZPM5IFwQuDAPoAtN1R_ELGNOBlSFOCVXdg/formResponse";
      

    }

}
