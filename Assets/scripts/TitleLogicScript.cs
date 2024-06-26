using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLogicScript : MonoBehaviour
{
    
    public void playGame ()
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame ()
    {
        Debug.Log("quit");
        Application.Quit();
    }

}
