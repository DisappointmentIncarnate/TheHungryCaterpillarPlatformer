using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseLife : MonoBehaviour
{
    //Code used to determine whether or not the player should go to a gameover screen or a lose life scene

    static int lastScene;
    static int remainingLives = 3;
    
    public static void ChangeScene(){
        if(remainingLives < 1){ //game over, return lives back to 3, and move back to menu
            SceneManager.LoadScene("Game Over");
            remainingLives = 3;
        }else{ //stores build index of last scene used and then moves to the lose life scene
            lastScene = SceneManager.GetActiveScene().buildIndex; 
            SceneManager.LoadScene("Lose Life");
            remainingLives--;
        }
    }

    public static void ReturnScene(){
        //returns back to before the lose life scene
        SceneManager.LoadScene(lastScene);
    }

    public static int livesAmount(){ //getter
        return remainingLives;
    }

}
