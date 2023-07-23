using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character2 : MonoBehaviour
{
    public GameObject knifePrefab; // Префаб ножа
    public float throwForce = 10f; // Сила броска
    public AudioClip[] moveSounds; // Массив звуков для воспроизведения при движении
    public AudioClip throwSound; // Звук для воспроизведения при броске ножа
    public AudioSource audioSource; // Аудиоисточник для проигрывания звуков
    public float soundInterval = 0.5f; // Пауза между звуками

    private float defaultRotation;
    public float moveSpeed = 5f;
    public float swayAmount = 5f;
    public float swaySpeed = 2f;
    public float bounceHeight = 0.1f;
    public float bounceFrequency = 5f;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool isMoving = false; // Флаг для отслеживания движения персонажа

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultRotation = rb.rotation;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Если нажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            //можно задать переменные такие как обьект и скорость
            ThrowKnife(throwForce, knifePrefab);
        }

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
            isMoving = false; // Персонаж больше не движется
        }
        else
        {
            isMoving = true; // Персонаж движется
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

        // Play move sound using coroutine
        if (isMoving && !audioSource.isPlaying)
        {
            StartCoroutine(PlayMoveSound());
        }
        else if (!isMoving)
        {
            audioSource.Stop(); // Остановить звуки, если персонаж не движется
        }
    }

    void ThrowKnife(float speed1, GameObject object1)
    {
        if (GetComponent<PlayerAttributes>().ammo > 0)
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
            ammoInstance.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

            GetComponent<PlayerAttributes>().DecreaseAmmo(1);
            // Воспроизводим звук броска ножа
            audioSource.PlayOneShot(throwSound);
        }
    }

    IEnumerator PlayMoveSound()
    {
        // Выбираем случайный звук из массива
        AudioClip randomSound = moveSounds[Random.Range(0, moveSounds.Length)];

        // Воспроизводим звук
        audioSource.PlayOneShot(randomSound);

        // Ждем заданный интервал времени перед проигрыванием следующего звука
        yield return new WaitForSeconds(soundInterval);

        // Запускаем корутину снова для повторного воспроизведения звука при следующем движении
        if (isMoving && audioSource.isPlaying)
        {
            StartCoroutine(PlayMoveSound());
        }
    }
}
