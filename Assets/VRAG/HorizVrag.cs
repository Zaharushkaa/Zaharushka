using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizVrag : MonoBehaviour
{
    public float speed = 0.5f; // �������� ��������
    public bool moveRight = true; // ���� ����������� ��������

    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "flag")
        {
            moveRight = !moveRight;
        }
    }
}
