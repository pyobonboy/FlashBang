using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target; // ���� ��� (ĳ����)

    public float moveSpeed = 3f; // �̵� �ӵ�
    public float stoppingDistance = 1f; // ĳ���Ϳ��� ���� �Ÿ�

    private void Update()
    {
        if (target != null)
        {
            // ĳ���͸� ���� �̵�
            Vector2 direction = target.position - transform.position;
            float distance = direction.magnitude;

            if (distance > stoppingDistance)
            {
                direction.Normalize();
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
        }
    }
}
