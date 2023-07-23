using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{


    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Health: " + player.GetComponent<HealthScript>().health + " Ammo: " + player.GetComponent<PlayerAttributes>().ammo + " Money: " + player.GetComponent<PlayerAttributes>().money + " Karma: " + player.GetComponent<PlayerAttributes>().karma;
    }
}
