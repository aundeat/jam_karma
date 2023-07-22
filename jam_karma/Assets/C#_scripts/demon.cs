using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demon : MonoBehaviour
{

    public float moveSpeed = 5f;

    public float bounceHeight = 0.1f;
    public float bounceFrequency = 5f;

    public float swayAmount = 10f;
    public float swaySpeed = 2f;

    private float defaultRotation;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private Vector2 moveDirection;
    private float nextChangeTime;

    private int choice;
    private bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        defaultRotation = rb.rotation;
    }

    void Update()
    {
        if (Time.time > nextChangeTime)
        {
            ChooseNewAction();
        }
    }

    void FixedUpdate()
    {

        if (!isMoving)
        {
            rb.rotation = defaultRotation;
        }

        if (isMoving)
        {
            // Bounce and sway
            // Bouncing
            Vector2 bounce = new Vector2(0, Mathf.Sin(Time.fixedTime * bounceFrequency) * bounceHeight);
            rb.velocity += bounce;

            // Swaying
            float sway = Mathf.Sin(Time.fixedTime * swaySpeed) * swayAmount;
            rb.rotation += sway;
        }

        // Move
        rb.velocity = moveDirection * moveSpeed;
    }

    void ChooseNewAction()
    {

        choice = Random.Range(0, 3);

        if (choice == 0)
        {
            // New direction
            moveDirection = Random.insideUnitCircle.normalized;
            nextChangeTime = Time.time + Random.Range(2, 5);
            isMoving = true;
        }
        else if (choice == 1)
        {
            // Pause
            moveDirection = Vector2.zero;
            nextChangeTime = Time.time + Random.Range(1, 3);
            isMoving = false;
        }

    }

}
