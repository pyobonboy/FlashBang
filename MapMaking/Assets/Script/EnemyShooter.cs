using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;  // �߻��� �Ѿ� ������
    public Transform firePoint;     // �Ѿ� �߻� ��ġ
    public float bulletSpeed = 5f;  // �Ѿ� �ӵ�
    public float shootInterval = 2f; // �߻� ����

    private Transform player;       // �÷��̾��� ��ġ
    private float shootTimer;       // �߻� Ÿ�̸�

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // �÷��̾��� Transform ������Ʈ�� ������
        shootTimer = shootInterval; // �ʱ� �߻� Ÿ�̸� ����
    }

    void Update()
    {
        // �߻� Ÿ�̸� ������Ʈ
        shootTimer -= Time.deltaTime;

        // �߻� Ÿ�̸Ӱ� 0 �����̰� �÷��̾ ������ ��
        if (shootTimer <= 0 && player != null)
        {
            // �Ѿ� �߻�
            Shoot();

            // �߻� ������ �缳��
            shootTimer = shootInterval;
        }
    }

    void Shoot()
    {
        // �Ѿ��� �����ϰ� �߻� ��ġ�� ������ ����
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // �Ѿ��� �÷��̾� �������� �̵���Ű�� ���� ���� ���� ���
        Vector2 direction = (player.position - firePoint.position).normalized;

        // �Ѿ˿� �ӵ��� ����
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
