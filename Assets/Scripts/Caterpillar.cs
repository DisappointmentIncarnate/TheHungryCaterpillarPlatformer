using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Caterpillar : MonoBehaviour
{
    private int hitpoints; //default 3 (at 0 the player loses)
    private int health; //default 4 (contributes to player speed, at 0 the player loses)
    public float speed; //0.2 is the float used in the first scene
    public float jump; //17 is the default used in the first scene
    public Sprite[] healthSprites;
    private int hitInvicibility; //ticks between when you can get hit
    private bool invincible = false; //flag for inviciblity after getting hit

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    private float horizontalMovement;
    Rigidbody2D rigidBody;
    SpriteRenderer spriteRender;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        hitpoints = 3;
        health = 4;
        hitInvicibility = 60;
    }

    public int get_hitpoints(){
        return hitpoints;
    }

    public int get_health(){
        return health;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal"); //Gets left & right key press
        gameObject.transform.position = new Vector2(transform.position.x + (horizontalMovement * speed), transform.position.y ); //transform x based upon direction & speed

        if(horizontalMovement == -1){ //if going left, flip sprite
            spriteRender.flipX = true;
        }else if (horizontalMovement == 1){ //else do not flip sprite
            spriteRender.flipX = false;
        }

        if(invincible){
            hitInvicibility--;
            if(hitInvicibility <= 0){
                spriteRender.enabled = true; //ensures sprite is back on by the end
                invincible = false;
                hitInvicibility = 60;
            }else if(hitInvicibility % 10 == 0){ //creates flashing effect by turning off and on
                spriteRender.enabled = false;
            }else if(hitInvicibility % 5 == 0){
                spriteRender.enabled = true;
            }

        }
    }
    
    void Update(){
        //if(Input.GetKeyDown(KeyCode.Space) && rigidBody.velocity.y == 0){ //if space pressed & if the player is not moving up or down (jumping or falling)
            //rigidBody.AddForce(transform.up * jump, ForceMode2D.Impulse); //add upward force to the rigidbody2d, using impulse force
        //}
        if (rigidBody.velocity.y == 0) //coyote time, gives the player a short time to jump after falling from the ground
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump")) //Jump buffer, players can buffer a jump slightly before landing 
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f) //full jump, hold down the button for a longer jump
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jump);

            jumpBufferCounter = 0f;

        }

        if (Input.GetButtonUp("Jump") && rigidBody.velocity.y > 0f) //half jump, tap the button for a short hop.
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }
        spriteUpdate();
    }

    void spriteUpdate(){
        spriteRender.sprite = healthSprites[health];
    }

    void OnCollisionEnter2D(Collision2D col){ //on collision with anything
        if(col.gameObject.tag == "boundary"){ //running into a "boundary" which is currently falling into void
            //instant death
            changeStat(10, 0,false); 
        }else if(col.gameObject.tag == "bad_item"){
            changeStat(1, 1, false);
            invincible = true;
        }else if(col.gameObject.tag == "good_item"){
            changeStat(1, 1, true);
            changeStat(1, 0, true);
        }else if(col.gameObject.tag == "enemy"){
            changeStat(1, 0, false);
            invincible = true;
        }
    }

    //passed variables (damage = amount to change, stat either 0 or 1, 0 flags hitpoints, 1 flags health, bool flag used to determine whehter to add or sub
    void changeStat(int damage, int stat, bool good){
        if(damage > 3){
            hitpoints = 0;
        }else{
            if(!good){
                if(stat == 0 && !invincible){ //reduce hit points
                    hitpoints = hitpoints - damage;
                }else if(stat == 1 && !invincible){ //reduce health
                    health = health - damage;
                    speed-=0.03f;
                }
            }else{
                if(stat == 0 && hitpoints < 3){ //increase hit points
                    hitpoints = hitpoints + damage;
                }else if(stat == 1 && health < 4){ //increase health
                    health = health + damage;
                    speed+=0.03f;
                }
            }
        }
        if(health <= 0 || hitpoints <= 0){ //player dies from damage
            LoseLife.ChangeScene();
        }
    }

}
