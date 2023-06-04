using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;  // 발사할 총알 프리팹
    public Transform firePoint;     // 총알 발사 위치
    public float bulletSpeed = 5f;  // 총알 속도
    public float shootInterval = 2f; // 발사 간격

    private Transform player;       // 플레이어의 위치
    private float shootTimer;       // 발사 타이머

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // 플레이어의 Transform 컴포넌트를 가져옴
        shootTimer = shootInterval; // 초기 발사 타이머 설정
    }

    void Update()
    {
        // 발사 타이머 업데이트
        shootTimer -= Time.deltaTime;

        // 발사 타이머가 0 이하이고 플레이어가 존재할 때
        if (shootTimer <= 0 && player != null)
        {
            // 총알 발사
            Shoot();

            // 발사 간격을 재설정
            shootTimer = shootInterval;
        }
    }

    void Shoot()
    {
        // 총알을 생성하고 발사 위치와 방향을 설정
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // 총알을 플레이어 방향으로 이동시키기 위해 방향 벡터 계산
        Vector2 direction = (player.position - firePoint.position).normalized;

        // 총알에 속도를 적용
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
