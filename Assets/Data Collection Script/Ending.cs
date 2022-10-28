using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Ending : MonoBehaviour
{
    public static Ending controller;


 
   // success or fail:  https://docs.google.com/forms/u/0/d/e/1FAIpQLSfrOv-juWUQm44PI0elUbVCGpDwUZ2BjUadGzIhOi4bxhVl4Q/formResponse
   [SerializeField] private string URL; 
   //new
   [SerializeField] private string level; 
 
   private long sessionID;
  // private string level;
    private string ending;

    private void Awake(){
      //  sessionID = System.DateTime.Now.Ticks;
        // Send();
    }

    void Start(){
       if(controller == null){
            controller = this;
         }
    }

    public void Send(string ending){
        sessionID = System.DateTime.Now.Ticks;
     //   level = currentLevel.instance.getLevel();
       // deathReason = "EnemyAttack";
        StartCoroutine(POST(sessionID.ToString(), level, ending));
    }

    private IEnumerator POST(string sessionID, string level, string ending){
        WWWForm form = new WWWForm();
        form.AddField("entry.1094553700",sessionID);
        form.AddField("entry.982391827",level);
        form.AddField("entry.2124429899",ending);
       
        using(UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
           // Debug.Log("url is: " + URL);
            yield return www.SendWebRequest();
            
            if(www.result != UnityWebRequest.Result.Success)
            {
               // Debug.Log(www.error);
            }
            /*
            if(www.error != null){
                Debug.Log(www.error);
            }*/
            else{
              //  Debug.Log("Form uploaded complete!");
            }
         }
    }
}
