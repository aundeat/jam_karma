using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai : MonoBehaviour
{
    public Vector2 movementBoundsMin; // ����������� ������� ��� �����������
    public Vector2 movementBoundsMax; // ������������ ������� ��� �����������
    public float moveSpeed = 2f; // �������� �����������
    public float maxAngle = 15f; // ������������ ���� ������� �������

    private Vector2 randomTarget; // ��������� ������� �������
    private float currentAngle = 0f; // ������� ���� ������� �������
    

    void Start()
    {
        // �������� �������� ��� ����������� ������
        StartWalking();
    }

    void Update()
    {
        // ���� ������ ������ ��������� ������� �������, ������� ����� ������� �������
        
        if (Vector2.Distance(transform.position, randomTarget) < 0.1f)
        {
            StartWalking();
        }
       

        // ����������� ������ � ������� ��������� ������� �������
        transform.position = Vector2.MoveTowards(transform.position, randomTarget, moveSpeed * Time.deltaTime);

        // ������� ������� �� ����� ��������
        currentAngle = Mathf.Sin(Time.time * moveSpeed*10) * maxAngle;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, currentAngle));
    }

    void StartWalking()
    {
        // �������� ��������� ������� ������� � �������� ��������
        float randomX = Random.Range(movementBoundsMin.x, movementBoundsMax.x);
        float randomY = Random.Range(movementBoundsMin.y, movementBoundsMax.y);
        randomTarget = new Vector2(randomX, randomY);
    }
}
