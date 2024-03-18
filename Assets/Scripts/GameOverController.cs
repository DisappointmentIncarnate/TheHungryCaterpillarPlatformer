using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    private bool finishCount = false;
    private int timer = 2500;

    // Update is called once per frame
    void Update()
    {
        if(!finishCount){
            timer--;
            if(timer <= 0 ){
                finishCount = true;
            }
        }else{
            SceneManager.LoadScene("Menu");
        }
    }
}
