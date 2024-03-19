using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    This entire thing was just an addition that doesn't really have anything to do with the main platformer game
    ExtraMode, ExtraHUDControl, parts of FallingItem / FlyingItems were modified to fit this additiona gamemode

*/

public class ExtraMode : MonoBehaviour
{
    private int hitpoints;
    public float speed;
    private int score;

    private int scoreInterval = 60;
    private int hitInvicibility;
    private bool invincible;

    private float horizontalMovement;
    private float verticalMovement;

    public ExtraHUDControl hud;
    private int finalTime = 3000;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        hitpoints = 3;
        hitInvicibility = 60;
        speed = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreInterval == 0){
            score++;
            scoreInterval = 60;
        }
        scoreInterval--;
        if(hitpoints <= 0){
            finalTime--;
        }
        if(finalTime == 0){
            SceneManager.LoadScene("Menu");
        }
    }

    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal"); //Gets left & right key press
        verticalMovement = Input.GetAxisRaw("Vertical");
        gameObject.transform.position = new Vector2(transform.position.x + (horizontalMovement * speed), transform.position.y + (verticalMovement * speed)); //transform x based upon direction & speed

        if(invincible){
            hitInvicibility--;
            if(hitInvicibility <= 0){
                sr.enabled = true; //ensures sprite is back on by the end
                invincible = false;
                hitInvicibility = 60;
            }else if(hitInvicibility % 10 == 0){ //creates flashing effect by turning off and on
                sr.enabled = false;
            }else if(hitInvicibility % 5 == 0){
                sr.enabled = true;
            }

        }
    }

    void OnCollisionEnter2D(Collision2D col){ //on collision with anything
        if(col.gameObject.tag == "bad_item"){
            if(hitpoints > 0 && !invincible){
                hitpoints--;
                invincible = true;
            }
        }
        if(hitpoints == 0){
            speed = 0;
            hud.activateFinal();
            hud.healthbar.enabled = false;
            hud.score.enabled = false;
            hitpoints--;
        }
    }

    public int get_hitpoints(){
        return hitpoints;
    }

    public int get_score(){
        return score;
    }
}
