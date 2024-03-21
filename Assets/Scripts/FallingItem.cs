using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItem : MonoBehaviour
{
    private int timer = 200;
    public bool side; //used only in extra mode
    public bool leftRight; //used only in extra mode
    Rigidbody2D item;
    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<Rigidbody2D>();
        if(side){
            timer = 300;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timer<0 && item.velocity.y == 0){ //break after time and hits ground
            Destroy(gameObject);
        }else{
            timer--;
        }

        if(side){
            if(leftRight){
                gameObject.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y);
            }else{
                gameObject.transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col){ //break on void hit
        if(col.gameObject.tag == "boundary"){
            Destroy(gameObject);
        }else if(col.gameObject.tag == "Player"){
            Destroy(this.gameObject);
        }
    }
}
