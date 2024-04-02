using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    public float distance = 4f;
    public float speed = 2f;
    public float wait = 4f;
    public bool state = false; // false � ����� true �����

    void Start()
    {
        StartCoroutine(MoveRightThenLeft());
    }

    IEnumerator MoveRightThenLeft()
    {
        while (true)
        {
            float startTime = Time.time;
            Vector3 startPos = transform.position;
            Vector3 endPos = startPos + Vector3.right * distance;
            // �������� ������
            if (state)
            {
                while (Time.time < startTime + distance / speed)
                {
                    transform.position = Vector3.Lerp(startPos, endPos, (Time.time - startTime) * speed / distance);
                    yield return null;
                }
                state = false;

                yield return new WaitForSeconds(wait); // ����� � ����� �������� ������
            }
            // �������� �����
            else
            {
                startTime = Time.time;
                startPos = transform.position;
                endPos = startPos - Vector3.right * distance;
                while (Time.time < startTime + distance / speed)
                {
                    transform.position = Vector3.Lerp(startPos, endPos, (Time.time - startTime) * speed / distance);
                    yield return null;
                }
                state = true;
                yield return new WaitForSeconds(wait); // ����� � ����� �������� �����
            }
        }
    } 
}

