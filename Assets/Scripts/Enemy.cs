using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;         //Speed of the platform
    public int startingPoint;   //Starting position of the platform
    public Transform[] points;  //Array of transform points
    public bool flip = true; //determins whether or not this enemy should flip x
    public bool defaultFlip;
    private bool alreadyFlip = true;
    SpriteRenderer image;


    private int i; // Array index

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<SpriteRenderer>();
        transform.position = points[startingPoint].position; //sets the starting position to one of the points
    }

    // Update is called once per frame
    void Update()
    {
        //Checking the distance of the platform and point
        if (Vector2.Distance(transform.position, points[i].position) <0.02)
        {
            i++; //indexing

            if(flip){ //if enemy should flipx
                if(!defaultFlip){
                    flipImage();
                }else{
                    reverseFlipImage();
                }
            }
            if (i == points.Length) //check if index is on the last point after indexing
            {
                i=0; //Resetting the index
            }
        }
        //Moving the platform to the point position with index "i"
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    void flipImage(){
        if(!alreadyFlip){ //flip
            image.flipX = true;
            alreadyFlip = true;
        }else{ //revert
            image.flipX = false;
            alreadyFlip = false;
        }
    }

    void reverseFlipImage(){
        if(!alreadyFlip){ //flip
            image.flipX = false;
            alreadyFlip = true;
        }else{ //revert
            image.flipX = true;
            alreadyFlip = false;
        }
    }
}

