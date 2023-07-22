using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ShootingAction 
{
    public enum ShootingType {Target, Random, Fixed };

    public ShootingType type;

    public int amount;
    public float spreadAngle;
    public float targetError;
    //Time waiting before next shot
    public float shootingInterval;

}
