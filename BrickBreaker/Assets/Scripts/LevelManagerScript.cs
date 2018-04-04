using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour {

    public void LoadLevel(string name){
        Debug.Log("Level load requested for: " + name);
        Brick.brickCount = 0;
        SceneManager.LoadScene(name);
        
    }
    
    public void QuitRequest(){
        Debug.Log("I want to quit");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
        print(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.brickCount <= 0) {
            LoadNextLevel();

        }
    }
}

