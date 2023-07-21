using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;



public class PlayerMovement2D : MonoBehaviour
{
    public float movementSpeed = 5f;

    private Vector2 moveDirection;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = transform;
    }

    void Update()
    {
        // Get horizontal and vertical input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the move direction
        moveDirection = new Vector2(horizontal, vertical).normalized;

        // Apply movement
        playerTransform.Translate(moveDirection * movementSpeed * Time.deltaTime);
    }
}

