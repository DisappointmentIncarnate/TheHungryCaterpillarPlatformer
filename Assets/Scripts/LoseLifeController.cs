using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseLifeController : MonoBehaviour
{
    // Code that executes on the scene where it displays a lost life
    
    private bool finishCount = false;
    private int timer = 1400;

    public TMP_Text lifeNum;

    // Update is called once per frame
    void Update()
    {
        if(!finishCount){
            timer--;
            if(timer <= 0 ){
                finishCount = true;
            }
        }else{
            LoseLife.ReturnScene();
        }
    }

    void Start(){ //change the text to properly adjust the lives
        lifeNum.text = " X   " + LoseLife.livesAmount(); 
    }
}
