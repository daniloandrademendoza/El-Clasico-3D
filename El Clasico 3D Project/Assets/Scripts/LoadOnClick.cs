using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadOnClick : MonoBehaviour {
    
    public void LoadScene(int level)
    {
        if(level==1)
        {
            SceneManager.LoadScene("GameScene");
        }
        else if(level==2)
        {
            SceneManager.LoadScene("MainMenuScene");
        }
        else if(level==3)
        {
            Application.Quit();
        }
        else if (level ==4)
        {
            
            SceneManager.LoadScene("PauseScene");
            
        }
    }
}
