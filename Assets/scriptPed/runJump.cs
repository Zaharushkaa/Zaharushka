using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class runJump : MonoBehaviour
{
    public static bool lvl = true;


    private Animator _animator;


    public TMP_Text coin;
    public static float coint_count = 0;


    public Image[] images; // ������ ����������� Image, ������� �� ������ ������
    private int health = 3;



    // ��������� ���� � ������
    public float speed = 3f;
    public float jumpForce = 4f;


    // ��������, ���������
    private bool isJump;
    private float getGravity;
    private float startPosX, startPosY;


    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        coin.text = coint_count.ToString();
        health = 3;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        getGravity = rb.gravityScale;

        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }


    void Update()
    {
        if (transform.position.y < -6.5f)
        {
            spawn();
        }
        beg();
        jump();
    }



    private void jump()
    {
        // ������
        if (!isJump && Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.05f)
        {
            isJump = true;
            rb.gravityScale = getGravity;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        }

        // ���������, ��������� �� �������� � �������
        if (isJump && rb.velocity.y < 0)
        {
            rb.gravityScale = 7;
        }
        else if (!isJump && rb.velocity.y < 0)
        {
            rb.gravityScale = 2;
        }

        
        // ������
        //  _animator.SetBool("isFall", isJump && rb.velocity.y < 0);

    }

    private void beg()
    {
        // ����������� ������ �����
        float movement = Input.GetAxis("Horizontal");

        bool isPlayerMoving = Mathf.Abs(movement) > 0.1f;
        _animator.SetBool("IsMoving", isPlayerMoving);
        // ����������� ������ �����
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;

        // ������� ���������
        if (movement > 0)
        {
            sr.flipX = false;
        }
        else if (movement < 0)
        {
            sr.flipX = true;
        }
    }


    private void spawn()
    {
          SceneManager.LoadScene("menu");
    }

    private void setPos()
    {

        Vector3 startPosition = new Vector3(startPosX, startPosY + 1f, transform.position.z);
        transform.position = startPosition;
        isJump = false;
    }
     
   

    public void HideImageFromIndex(int index)
    {
        if (index >= 0 && index < images.Length)
        {
            images[index].enabled = false; // ������������� �������� enabled ��� ����������� � �������� �������� � �������� false
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //    Debug.Log($"{collision.name}"); // �������� ��� �������  � ������� ��������������� ��� PED

        if (collision.isTrigger)
        {
            rb.gravityScale = getGravity;
            isJump = false;
        }

        if(collision.tag == "coin")
        {
            coint_count++;
            coin.text = coint_count.ToString();
            Destroy(collision.gameObject);
        }

        if (collision.tag == "vrag")
        {

            if (health == 3)
            {
                health--;
                HideImageFromIndex(2);

            }
            else if (health == 2)
            {
                health--;
                HideImageFromIndex(1);
            }
            else if (health == 1)
            {
                health--;
                HideImageFromIndex(0);
            }
            else if (health == 0)
            {
                SceneManager.LoadScene("menu");
            }
        }
        if (collision.tag == "fin1")
        {
            Debug.Log("Send");
            runJump.lvl = true;
            Invoke("LoadSceneWithDelay", 1f);
        }
        if(collision.tag == "fin2")
        {
            Debug.Log("Send");
            runJump.lvl = false;
            Invoke("LoadSceneWithDelay", 1f);
        }
    }

    void LoadSceneWithDelay()
    {
        SceneManager.LoadScene("play2");
    }

    void LoadSceneWithDelay2()
    {
        SceneManager.LoadScene("menu");
    }

    private void OnDestroy()
    {
        GlobalVariables.coinCount = coint_count; // ���������� coint_count
    }

    public static class GlobalVariables
    {
        public static float coinCount = 0;
    }
    public GameObject settingPanel;
}
    

