using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public int karma;
    public int ammo;
    public int money;

    public int attackStrength;

    public Vector2 currentCheckpoint;


    private void Start()
    {
        currentCheckpoint = transform.position;
    }


    public void IncreaseAmmo(int amount)
    {
        ammo += amount;
    }

    public void DecreaseAmmo(int amount) {  
        ammo -= amount;
    }

    public void IncreaseKarma(int amount)
    {
        karma += amount;

        if (karma > 0)
        {
            attackStrength = 2;
        }
    }

    public void DecreaseKarma(int amount)
    {
        karma -= amount;

        if (karma < 0)
        {
            attackStrength = 1;
        }
    }

    public void IncreaseMoney(int amount)
    {
        money += amount;
    }

    public void DecreaseMoney(int amount)
    {
        money -= amount;
    }
}
