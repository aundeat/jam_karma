using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;



public class PlayerMovement2D : MonoBehaviour
{

    public GameObject knifePrefab; // ������ ����
    public float throwForce = 10f; // ���� ������


    public float movementSpeed = 5f;

    private Vector2 moveDirection;
    private Transform playerTransform;
    public Animator animator;
    void Start()
    {
        playerTransform = transform;
    }

    void Update()
    {
       // animator.SetFloat("Horizontal", moveDirection.y);
       // animator.SetFloat("Vertical", moveDirection.x);
        //animator.SetFloat("speed", moveDirection.magnitude);

        // ���� ������ ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            //����� ������ ���������� ����� ��� ������ � ��������
            ThrowKnife(throwForce,knifePrefab);
        }

        // Get horizontal and vertical input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the move direction
        moveDirection = new Vector2(horizontal, vertical).normalized;

        
        
            // Apply movement
            playerTransform.Translate(moveDirection * movementSpeed * Time.deltaTime);
            
    }
    void ThrowKnife(float speed1, GameObject object1)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // ������ Z-���������� ������ 0

        // ��������� ����������� ������
        Vector2 throwDirection = (mousePosition - transform.position).normalized;

        // ������� ��������� ����
        GameObject ammoInstance = Instantiate(object1, transform.position, Quaternion.identity);

        // ������� ���� �������� ������
        Rigidbody2D knifeRigidbody = ammoInstance.GetComponent<Rigidbody2D>();
        knifeRigidbody.velocity = throwDirection * throwForce;
        // ������� ��������
        float angle = Mathf.Atan2(throwDirection.y, throwDirection.x) * Mathf.Rad2Deg;
        ammoInstance.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));

    }
}

