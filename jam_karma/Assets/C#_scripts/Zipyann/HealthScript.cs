using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    //amount of health
    public int health;

    //Cooldown before object can be damaged again
    public float damageCooldown;

    private bool isCooldown;

    private float cooldownTime;

    //start health at the beginning
    private int defaultHealth;

    void Start()
    {
        defaultHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(isCooldown && Time.time > cooldownTime)
        {
            isCooldown = false;
        }
    }

    public void DecreaseHealth(int amount)
    {
        if (!isCooldown) {
            health -= amount;

            cooldownTime = Time.time + damageCooldown;

            isCooldown = true;


            if (health <= 0)
            {
                if (gameObject.CompareTag("Enemy"))
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
        }
       
    }

    public void IncreaseHealth(int amount) 
    { 
        health += amount; 
    }
}
