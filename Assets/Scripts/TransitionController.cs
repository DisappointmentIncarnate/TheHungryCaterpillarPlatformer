using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour
{
    private bool finishCount = false;
    private int timer = 1400;
    static int lastScene;
    private string text;
    public Sprite[] fruits;

    public TMP_Text levelText;
    public Image fruit1;
    public Image fruit2;
    public Image fruit3;
    public Image fruit4;
    public Image fruit5;

    // Update is called once per frame
    void Update()
    {
        if(!finishCount){
            timer--;
            if(timer <= 0 ){
                finishCount = true;
            }
        }else{
            SceneManager.LoadScene(++lastScene);
        }
    }

    void Awake(){ //change the text to properly adjust the lives
        switch(lastScene){
            case 0:
                text = "On Monday";
                fruit1.sprite = fruits[lastScene];
                break;
            case 1:
                text = "On Tuesday";
                fruit1.sprite = fruits[lastScene];
                fruit2.sprite = fruits[lastScene];
                break;
            case 2:
                text = "On Wednesday";
                fruit1.sprite = fruits[lastScene];
                fruit2.sprite = fruits[lastScene];
                fruit3.sprite = fruits[lastScene];
                break;
            case 3:
                text = "On Thursday";
                fruit1.sprite = fruits[lastScene];
                fruit2.sprite = fruits[lastScene];
                fruit3.sprite = fruits[lastScene];
                fruit4.sprite = fruits[lastScene];
                break;
            case 4:
                text = "On Friday";
                fruit1.sprite = fruits[lastScene];
                fruit2.sprite = fruits[lastScene];
                fruit3.sprite = fruits[lastScene];
                fruit4.sprite = fruits[lastScene];
                fruit5.sprite = fruits[lastScene];
                break;
            case 5:
                text = "On The Final Day";
                fruit3.sprite = fruits[lastScene];
                break;
            default:
                SceneManager.LoadScene("Ending");
                break;
        }
        levelText.text = text; 
    }

    public static void getCurrentScene(){
        lastScene = SceneManager.GetActiveScene().buildIndex; 
    }
}
