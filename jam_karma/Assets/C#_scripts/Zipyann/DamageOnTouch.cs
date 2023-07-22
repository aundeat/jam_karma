using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    //Damages Player character
    public bool damagePlayer;

    //Damages Enemies
    public bool damageEnemy;

    //Amount of damage done
    public int damageAmount;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if((damageEnemy && other.gameObject.CompareTag("Enemy")) || (damagePlayer && other.gameObject.CompareTag("Player")))
        {
            //Damage enemy or player
            other.gameObject.GetComponent<HealthScript>().DecreaseHealth(damageAmount);
        }

       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((damageEnemy && other.gameObject.CompareTag("Enemy")) || (damagePlayer && other.gameObject.CompareTag("Player")))
        {
            //Damage enemy or player
            other.gameObject.GetComponent<HealthScript>().DecreaseHealth(damageAmount);
        }
    }
}
