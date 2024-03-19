using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void startGame(){
        SceneManager.LoadScene("Level 1");
    }

    public void closeGame(){
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false; //probably not necessary but nice while testing
    }

    public void extraGame(){
        SceneManager.LoadScene("Extra");
    }

}
