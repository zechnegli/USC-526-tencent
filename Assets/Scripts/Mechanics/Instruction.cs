using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instruction : MonoBehaviour
{
    public string firstLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void FirstButton(){

    SceneManager.LoadScene(firstLevel);
    
    
    }

    
    public void QuitGame(){
    /*
        quit the game
    */
    Application.Quit();
    
    }
}
