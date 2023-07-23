using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{

    public int health;
    public int ammo;
    public int maxHealthBonus;
    public bool canSteal;

    private GameObject player;
    private bool canTake;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(canTake && Input.GetKeyDown(KeyCode.E)) {

            //Take item
            player.GetComponent<HealthScript>().IncreaseHealth(health);
            player.GetComponent<HealthScript>().IncreaseMaxHealth(maxHealthBonus);
            player.GetComponent<PlayerAttributes>().IncreaseAmmo(ammo);


            if(canSteal)
            {
                player.GetComponent<PlayerAttributes>().DecreaseKarma(1);
            }

            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canTake = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canTake = false;
        }
    }
}