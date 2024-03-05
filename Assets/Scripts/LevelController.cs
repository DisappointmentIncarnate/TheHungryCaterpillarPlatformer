using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    //Attach this to anything on the scene, for level 1, this and camera controller are attached to main camera

    public int pickups;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks for good item pickups every frame, probably inefficient but who cares
        pickups = GameObject.FindGameObjectsWithTag("good_item").Length; 
        if(pickups == 0){ //when no more items left to pick up are on the scene, change scene
            SceneManager.LoadScene("Menu");
        }
    }
}
