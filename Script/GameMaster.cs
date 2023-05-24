using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class  GameMaster: MonoBehaviour//NewBehaviourScript
{
    public void GoToGameScene()
    {
        SceneManager.LoadScene("Scan");
    }

    public void GoToCollectScene()
    {
        SceneManager.LoadScene("Collections");
    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
