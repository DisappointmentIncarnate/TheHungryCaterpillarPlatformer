using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Caterpillar : MonoBehaviour
{
    public int hitpoints; //default 3 (at 0 the player loses)
    public int health; //default 4 (contributes to player speed, at 0 the player loses)
    public float speed; //0.01 is the float used in the first scene
    public float jump; //17 is the default used in the first scene
    public Sprite[] healthSprites;
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
    }
    
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && rigidBody.velocity.y == 0){ //if space pressed & if the player is not moving up or down (jumping or falling)
            rigidBody.AddForce(transform.up * jump, ForceMode2D.Impulse); //add upward force to the rigidbody2d, using impulse force
        }
        spriteUpdate();
    }

    void OnCollisionEnter2D(Collision2D col){ //on collision with anything
        if(col.gameObject.tag == "boundary"){ //running into a "boundary" which is currently falling into void
            //instant death, move back to menu 
            Destroy(this.gameObject); 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }else if(col.gameObject.tag == "bad_item"){
            changeStat(1, 1, false);
        }else if(col.gameObject.tag == "good_item"){
            changeStat(1, 1, true);
            changeStat(1, 0, true);
        }else if(col.gameObject.tag == "enemy"){
            changeStat(1, 0, false);
        }
    }

    //passed variables (damage = amount to change, stat either 0 or 1, 0 flags hitpoints, 1 flags health, bool flag used to determine whehter to add or sub
    void changeStat(int damage, int stat, bool good){
        if(!good){
            if(stat == 0){ //reduce hit points
                hitpoints = hitpoints - damage;
            }else if(stat == 1){ //reduce health
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
        if(health <= 0 || hitpoints <= 0){ //player dies from damage
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void spriteUpdate(){
        spriteRender.sprite = healthSprites[health];
    }
}
