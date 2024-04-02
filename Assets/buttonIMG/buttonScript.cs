using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    public void PlayGame()
    {
        if(runJump.lvl)
        {
            runJump.coint_count = 0;
            SceneManager.LoadScene("play");
        }
        else
        {
            runJump.coint_count = 0;
            SceneManager.LoadScene("play2");
        }
    }
      
    public void Exit()
    {
        Application.Quit();
    }

}
