using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instruction2 : MonoBehaviour
{
    public string secondLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void FirstButton(){

    SceneManager.LoadScene(secondLevel);
    
    
    }

    
    public void QuitGame(){
    /*
        quit the game
    */
    Application.Quit();
    
    }
}
