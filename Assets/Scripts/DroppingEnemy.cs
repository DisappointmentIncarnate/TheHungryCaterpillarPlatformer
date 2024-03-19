using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingEnemy : MonoBehaviour
{
    public float speed;         //Speed of the platform
    public int startingPoint;   //Starting position of the platform
    public Transform[] points;  //Array of transform points

    public GameObject itemPrefab;
    public int internalCooldown = 1500;
    private bool dropItem = true;

    private int i; // Array index

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position; //sets the starting position to one of the points
    }

    // Update is called once per frame
    void Update()
    {
        //Checking the distance of the platform and point
        if (Vector2.Distance(transform.position, points[i].position) <0.02)
        {
            i++; //indexing
            if (i == points.Length) //check if index is on the last point after indexing
            {
                i=0; //Resetting the index
            }
        }
        //Moving the platform to the point position with index "i"
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);   
    }

    void FixedUpdate(){
        activateDrop();
    }

    void activateDrop(){
        if(internalCooldown <= 0 && dropItem){
            GameObject item = Instantiate(itemPrefab, transform.position, transform.rotation);
            dropItem = false;
            internalCooldown = Random.Range(100, 3000);
        }else{
            dropItem = true;
            internalCooldown--;
        }
    }
}

