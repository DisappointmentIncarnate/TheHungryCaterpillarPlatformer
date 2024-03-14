using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingPlatform : MonoBehaviour
{
    public float speed;         //Speed of the platform
    public int startingPoint;   //Starting position of the platform
    public Transform[] points;  //Array of transform points
    private bool collide = false;

    private int i; // Array index

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position; //sets the starting position to one of the points
    }

    // Update is called once per frame
    void Update()
    {
        if(collide){
            //Checking the distance of the platform and point
            if (Vector2.Distance(transform.position, points[i].position) <0.02)
            {
                i++; //indexing
                if(i == points.Length) //check if index is on the last point after indexing
                {
                    i=0; //Resetting the index
                }
            }
            //Moving the platform to the point position with index "i"
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
    }
    //Moves the player when entering the platform
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        collide = true;
        if(collision.transform.position.y > transform.position.y)
        {
         collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collide = false;
        collision.transform.SetParent(null);
    }
    
}

