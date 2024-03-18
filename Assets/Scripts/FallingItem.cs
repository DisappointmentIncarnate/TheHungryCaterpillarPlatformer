using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItem : MonoBehaviour
{
    private int timer = 800;
    Rigidbody2D item;
    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer<0 && item.velocity.y == 0){ //break after time and hits ground
            Destroy(gameObject);
        }else{
            timer--;
        }
    }

    void OnCollisionEnter2D(Collision2D col){ //break on void hit
        if(col.gameObject.tag == "boundary"){
            Destroy(gameObject);
        }
    }
}
