using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    private bool finishCount = false;
    private int timer;

    public Sprite[] endingAni;
    private int aniCount;
    public Image caterpillar;
    public Image butterfly;

    void Start(){
        if(SceneManager.GetActiveScene().name != "Ending"){
            timer = 2500;
        }else{
            butterfly.enabled = false;
            aniCount = endingAni.Length-1;
            timer = 10000;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Ending"){ //regular game over
            if(!finishCount){
                timer--;
                if(timer <= 0 ){
                    finishCount = true;
                }
            }else{
                SceneManager.LoadScene("Menu");
            }
        }else{ //ending screen
            if(!finishCount){
                timer--;
                if(timer <= 0 ){
                    finishCount = true;
                }
                if(timer % 1000 == 0){
                    if(aniCount != -1 ){
                        caterpillar.sprite = endingAni[aniCount];
                        aniCount--;
                    }else{
                        caterpillar.enabled = false;
                        butterfly.enabled = true;
                    }
                }
            }else{
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
