using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExtraHUDControl : MonoBehaviour
{
    public Image healthbar;
    public TMP_Text score;
    public TMP_Text finalScore;
    public ExtraMode player;
    public Sprite[] hearts;

    private int totalFood;
    private int collectedFood;
    // Start is called before the first frame update
    void Start()
    {
        finalScore.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if(player.get_hitpoints() > 3 || player.get_hitpoints() < 0){
            //if exception do nothing to not pass arrayoutofbounds exception
        }else{
            healthbar.sprite = hearts[player.get_hitpoints()]; //updates health bar
        }
        score.text = "Score: " + player.get_score();
    }

    public void activateFinal(){
        finalScore.enabled = true;
        finalScore.text = "FINAL SCORE: " + player.get_score();
    }
}
