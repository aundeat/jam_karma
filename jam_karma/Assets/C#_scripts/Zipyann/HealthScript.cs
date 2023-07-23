using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    //amount of health
    public int health;

    public int maxHealth;

    //Cooldown before object can be damaged again
    public float damageCooldown;

    private bool isCooldown;

    private float cooldownTime;

    //start health at the beginning
    private int defaultHealth;

    private FlashScript flashScript;

    void Start()
    {
        defaultHealth = health;

        flashScript = GetComponent<FlashScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCooldown && Time.time > cooldownTime)
        {
            isCooldown = false;

            if (flashScript != null)
            {
                flashScript.StopFlashing();
            }
        }
    }

    public void DecreaseHealth(int amount)
    {
        if (!isCooldown) {
            health -= amount;

            cooldownTime = Time.time + damageCooldown;

            isCooldown = true;

            if (flashScript != null)
            {
                flashScript.StartFlashing();
            }


            if (health <= 0)
            {
                if (gameObject.CompareTag("Enemy") || gameObject.CompareTag("Villager"))
                {
                    //Kill enemy
                    gameObject.SetActive(false);
                }
                else if (gameObject.CompareTag("Player"))
                {
                    //TODO: Kill Player (respawn at last checkpoint with less ammo or karma??)
                    //Test: Respawn at checkpoint
                    health = defaultHealth;
                    gameObject.transform.position = Vector3.zero;

                }
            }

            //TODO: Update UI

        }

    }

    public void IncreaseHealth(int amount) 
    { 
        health += amount; 

        if(health >= maxHealth)
        {
            health = maxHealth;
        }

        //TODO: Update UI
    }


    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;

        //TODO: update Ui
    }

    public void DecreaseMaxHealth(int amount)
    {
        maxHealth -= amount;

        if(maxHealth <= 0)
        {
            maxHealth = 0;
        }

        //TODO: Update UI
    }
}
