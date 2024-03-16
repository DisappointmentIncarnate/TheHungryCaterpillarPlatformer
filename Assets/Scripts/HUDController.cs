using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    public Image healthbar;
    public TMP_Text food;
    public Caterpillar player;
    public Sprite[] hearts;

    private int totalFood;
    private int collectedFood;
    // Start is called before the first frame update
    void Start()
    {
        totalFood = GameObject.FindGameObjectsWithTag("good_item").Length;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.sprite = hearts[player.get_hitpoints()]; //updates health bar
        collectedFood = totalFood - GameObject.FindGameObjectsWithTag("good_item").Length;
        food.text = "Food: " + collectedFood + " / " + totalFood;
    }
}
