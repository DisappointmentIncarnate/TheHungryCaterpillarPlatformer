using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caterpillar : MonoBehaviour
{
    public float speed; //0.01 is the float used in the first scene
    public float jump; //17 is the default used in the first scene
    private float horizontalMovement;
    Rigidbody2D rigidBody;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal"); //Gets left & right key press
        gameObject.transform.position = new Vector2(transform.position.x + (horizontalMovement * speed), transform.position.y ); //transform x based upon direction & speed

        if(Input.GetKeyDown(KeyCode.Space) && rigidBody.velocity.y == 0){ //if space pressed & if the player is not moving up or down (jumping or falling)
            rigidBody.AddForce(transform.up * jump, ForceMode2D.Impulse); //add upward force to the rigidbody2d, using impulse force
        }

        if(horizontalMovement == -1){ //if going left, flip sprite
            sprite.flipX = true;
        }else if (horizontalMovement == 1){ //else do not flip sprite
            sprite.flipX = false;
        }
    }
}
