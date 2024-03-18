using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Sprite[] badItems;
    SpriteRenderer spriteRender;

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            Destroy(this.gameObject);
        }
    }

    void Start(){
        spriteRender = GetComponent<SpriteRenderer>();
        if (gameObject.tag == "bad_item"){
            spriteRender.sprite = badItems[Random.Range(0, badItems.Length)]; //random item from list of items
            gameObject.transform.localScale += new Vector3(2.5f,2.5f,0); //since we're using 32x32 textures, scale up
        }
    }
}
