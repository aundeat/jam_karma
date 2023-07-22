using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caracter2 : MonoBehaviour
{

    private float defaultRotation;

    public float moveSpeed = 5f;
    public float swayAmount = 5f;
    public float swaySpeed = 2f;

    public float bounceHeight = 0.1f;
    public float bounceFrequency = 5f;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultRotation = rb.rotation;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        // Get input
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(x, y).normalized;

        // Flip sprite
        if (x < 0)
        {
            sprite.flipX = true;
        }
        else if (x > 0)
        {
            sprite.flipX = false;
        }

    }

    void FixedUpdate()
    {

        Vector2 currentMove = moveInput;

        if (moveInput == Vector2.zero)
        {
            rb.rotation = defaultRotation;
        }

        // Sway
        if (moveInput != Vector2.zero)
        {
            float sway = Mathf.Sin(Time.fixedTime * swaySpeed) * swayAmount;
            rb.rotation += sway;
        }

        // Bounce
        Vector2 bounce = Vector2.zero;
        if (moveInput != Vector2.zero)
        {
            bounce = new Vector2(0, Mathf.Sin(Time.fixedTime * bounceFrequency) * bounceHeight);
        }

        // Move
        rb.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed) + bounce;

        moveInput = Vector2.zero;

    }

}