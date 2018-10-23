using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }
}
