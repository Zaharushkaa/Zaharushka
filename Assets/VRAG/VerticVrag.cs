using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticVrag : MonoBehaviour
{
    public float speed = 5f; // �������� �������� �����
    private Rigidbody2D rb;
    private bool movingUp = true; // ���� ��� ����������� �������� �����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // ��������� ���������� ��� �����
    }

    void FixedUpdate()
    {
        // ����������� ����� ����� ��� ���� � ����������� �� ����� movingUp
        float movement = movingUp ? 1 : -1;
        rb.velocity = new Vector2(0f, movement * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("flag"))
        {
            // ��������� ����������� �������� ����� ��� ������������ � ����������� � ����� "flag"
            movingUp = !movingUp;
        }
    }
}
