using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedMenu : MonoBehaviour
{
    public string restartLevel;
     public string nextLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Proceed to the next level
    public void NextLevel() {
        SceneManager.LoadScene(nextLevel);
    }

    // Restart this level
    public void RestartGame() {
        SceneManager.LoadScene(restartLevel);
    }

    // Quit the game
    public void QuitGame(){
        SceneManager.LoadScene("MainMenu");
    }
}