using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;
    public string secondLevel;
    public string thirdLevel;
    public string fourthLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame(){
    /*
        start the game
    */
    SceneManager.LoadScene(firstLevel);
    
    
    }

    public void SecondLevel(){
        SceneManager.LoadScene(secondLevel);
    }

    public void ThirdLevel(){
        SceneManager.LoadScene(thirdLevel);
    }

    public void FourthLevel(){
        SceneManager.LoadScene(fourthLevel);
    }
    
    public void Instructions(){
    /*
        open the instructions window
    */
    
    }
    
    public void QuitGame(){
    /*
        quit the game
    */
    Application.Quit();
    
    }
}
