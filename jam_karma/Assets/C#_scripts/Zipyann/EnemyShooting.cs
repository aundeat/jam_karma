using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float projectileSpeed;

    public bool canShoot;

    [SerializeField]
    public List<ShootingAction> shootingActions = new List<ShootingAction>();
    public Transform target;
    private float nextShootingTime;
    private ShootingAction currentShootingAction;
    private int shootingCount;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }


    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextShootingTime)
        {
            currentShootingAction = shootingActions[shootingCount];
            shootingCount++;
            shootingCount %= shootingActions.Count;

            nextShootingTime = Time.time + currentShootingAction.shootingInterval;


            // Calculate the direction to the player
            Vector3 directionToTarget = (target.position + (Vector3)(Random.insideUnitCircle.normalized) * currentShootingAction.targetError - transform.position).normalized;

            // Calculate the rotation angle to face the player
            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg - 90f;

            // Shoot spread of bullets
            for (int i = 0; i < currentShootingAction.amount; i++)
            {
                // Calculate the spread angle for each bullet
                float spreadOffset = (i - (currentShootingAction.amount - 1) / 2f) * currentShootingAction.spreadAngle;

                // Calculate the rotation for the bullet direction
                Quaternion bulletRotation = Quaternion.Euler(new Vector3(0f, 0f, angle + spreadOffset));

                if (canShoot)
                {
                    // Instantiate the bullet at the enemy's position with the calculated rotation
                    GameObject bullet = Instantiate(projectilePrefab, transform.position, bulletRotation);

                    // Add force to the bullet to move it towards the player
                    bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * projectileSpeed;
                }

                
            }
        }


    }
}
