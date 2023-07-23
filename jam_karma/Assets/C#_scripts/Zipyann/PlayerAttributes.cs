using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public int karma;
    public int ammo;
    public int money;

    public Transform currentCheckpoint;

    

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
    }

    public void DecreaseKarma(int amount)
    {
        karma -= amount;
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
