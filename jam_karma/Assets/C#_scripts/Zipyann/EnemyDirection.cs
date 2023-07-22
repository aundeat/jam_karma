using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyDirection
{

    public enum DirectionType { FollowTarget, MoveRandom, MoveDirection };

    public Vector2 direction;
    public float speed;
    public float duration;

    //Amount of deviation from target when following
    public float followError;
    public DirectionType type;
}
