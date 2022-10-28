using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instruction3 : MonoBehaviour
{
    public string thirdLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void FirstButton(){

    SceneManager.LoadScene(thirdLevel);
    
    
    }

    
    public void QuitGame(){
    /*
        quit the game
    */
    Application.Quit();
    
    }
}
