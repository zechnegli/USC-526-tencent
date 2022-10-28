using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class DeathReason : MonoBehaviour
{
    public static DeathReason controller;


   // [SerializeField] private string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdO5uozMk7wirbGFalIX_Mw7jXikC8IlRxzWaqJBSQouQLrOw/formResponse";
   [SerializeField] private string URL; 
   //new
   [SerializeField] private string level; 
   private long sessionID;
  // private string level;
    private string deathReason;

    private void Awake(){
      //  sessionID = System.DateTime.Now.Ticks;
        // Send();
    }

    void Start(){
       if(controller == null){
            controller = this;
         }
    }

    public void Send(string reason){
        sessionID = System.DateTime.Now.Ticks;
     //   level = currentLevel.instance.getLevel();
       // deathReason = "EnemyAttack";
        StartCoroutine(POST(sessionID.ToString(), level, reason));
    }

    private IEnumerator POST(string sessionID, string level, string reason){
        WWWForm form = new WWWForm();
        form.AddField("entry.1076048271",sessionID);
         form.AddField("entry.1358377684",level);
        form.AddField("entry.856080154",reason);
       
        using(UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
           // Debug.Log("url is: " + URL);
            yield return www.SendWebRequest();
            
            if(www.result != UnityWebRequest.Result.Success)
            {
              //  Debug.Log(www.error);
            }
            /*
            if(www.error != null){
                Debug.Log(www.error);
            }*/
            else{
            //    Debug.Log("Form uploaded complete!");
            }
         }
    }
}
