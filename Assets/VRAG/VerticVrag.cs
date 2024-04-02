using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticVrag : MonoBehaviour
{
    public float speed = 5f; // Скорость движения врага
    private Rigidbody2D rb;
    private bool movingUp = true; // Флаг для направления движения врага

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // Отключаем гравитацию для врага
    }

    void FixedUpdate()
    {
        // Перемещение врага вверх или вниз в зависимости от флага movingUp
        float movement = movingUp ? 1 : -1;
        rb.velocity = new Vector2(0f, movement * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("flag"))
        {
            // Изменение направления движения врага при столкновении с коллайдером с тегом "flag"
            movingUp = !movingUp;
        }
    }
}
