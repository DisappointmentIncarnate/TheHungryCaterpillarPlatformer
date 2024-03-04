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
    }

    // Start is called before the first frame update
    void Start()
    {
        //idk if theres anything we need these 2 methods for right now, but i'll leave them here.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
