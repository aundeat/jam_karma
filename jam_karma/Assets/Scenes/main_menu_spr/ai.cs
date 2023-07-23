using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai : MonoBehaviour
{
    public Vector2 movementBoundsMin; // ћинимальные границы дл€ перемещени€
    public Vector2 movementBoundsMax; // ћаксимальные границы дл€ перемещени€
    public float moveSpeed = 2f; // —корость перемещени€
    public float maxAngle = 15f; // ћаксимальный угол наклона спрайта

    private Vector2 randomTarget; // —лучайна€ целева€ позици€
    private float currentAngle = 0f; // “екущий угол наклона спрайта
    

    void Start()
    {
        // «апустим корутину дл€ перемещени€ жител€
        StartWalking();
    }

    void Update()
    {
        // ≈сли житель достиг случайной целевой позиции, выберем новую целевую позицию
        
        if (Vector2.Distance(transform.position, randomTarget) < 0.1f)
        {
            StartWalking();
        }
       

        // ѕеремещение жител€ в сторону случайной целевой позиции
        transform.position = Vector2.MoveTowards(transform.position, randomTarget, moveSpeed * Time.deltaTime);

        //  ачание спрайта во врем€ движени€
        currentAngle = Mathf.Sin(Time.time * moveSpeed*10) * maxAngle;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, currentAngle));
    }

    void StartWalking()
    {
        // ¬ыбираем случайную целевую позицию в заданных границах
        float randomX = Random.Range(movementBoundsMin.x, movementBoundsMax.x);
        float randomY = Random.Range(movementBoundsMin.y, movementBoundsMax.y);
        randomTarget = new Vector2(randomX, randomY);
    }
}
