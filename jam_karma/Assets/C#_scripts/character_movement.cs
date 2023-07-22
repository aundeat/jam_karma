using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;



public class PlayerMovement2D : MonoBehaviour
{

    public GameObject knifePrefab; // Префаб ножа
    public float throwForce = 10f; // Сила броска


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

        // Если нажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            //можно задать переменные такие как обьект и скорость
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
        mousePosition.z = 0f; // Задаем Z-координату равной 0

        // Вычисляем направление броска
        Vector2 throwDirection = (mousePosition - transform.position).normalized;

        // Создаем экземпляр ножа
        GameObject ammoInstance = Instantiate(object1, transform.position, Quaternion.identity);

        // Придаем ножу скорость броска
        Rigidbody2D knifeRigidbody = ammoInstance.GetComponent<Rigidbody2D>();
        knifeRigidbody.velocity = throwDirection * throwForce;
        // поворот предмета
        float angle = Mathf.Atan2(throwDirection.y, throwDirection.x) * Mathf.Rad2Deg;
        ammoInstance.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));

    }
}

