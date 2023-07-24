using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{


    public GameObject target;

    public bool canMove;

    [SerializeField]
    public List<EnemyDirection> directions = new List<EnemyDirection>();

    private EnemyDirection currentDirection;

    private Rigidbody2D rb;

    private bool followPlayer;

    private Vector2 moveDirection;

    private float switchDirectionTime;

    private int directionCounter;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player");


        currentDirection = directions[0];
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > switchDirectionTime)
        {

            

            currentDirection = directions[directionCounter];

            directionCounter++;
            directionCounter %= directions.Count;

            switchDirectionTime = Time.time + currentDirection.duration;


            if (currentDirection.type == EnemyDirection.DirectionType.FollowTarget)
            {
                moveDirection = (target.transform.position + (Vector3)(Random.insideUnitCircle.normalized) * currentDirection.followError - transform.position).normalized;

            }
            else if (currentDirection.type == EnemyDirection.DirectionType.MoveRandom)
            {
                //Else choose random direction
                moveDirection = Random.insideUnitCircle.normalized;
            }
            else if (currentDirection.type == EnemyDirection.DirectionType.MoveDirection)
            {
                //Move Into Fixed Direction
                moveDirection = currentDirection.direction;
            }

        }

        if(canMove)
        {
            rb.velocity = moveDirection * currentDirection.speed;

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        //Swap direction on collide:

        if (other.gameObject.CompareTag("Wall"))
        {
            moveDirection = -moveDirection;
        }
    }
}