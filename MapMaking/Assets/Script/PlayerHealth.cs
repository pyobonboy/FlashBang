using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // 최대 체력
    public int currentHealth; // 현재 체력

    void Start()
    {
        currentHealth = maxHealth; // 최대 체력으로 초기화
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount; // 체력 변경
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 체력이 최대 체력을 넘지 않도록 클램핑
        if (currentHealth <= 0)
        {
            Die(); // 체력이 0 이하일 경우 사망 처리
        }
    }

    void Die()
    {
        Debug.Log("캐릭터 사망");
        // 사망 처리에 대한 추가 로직을 구현하세요.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            ModifyHealth(-10); // 체력을 10 감소시킴

            Destroy(collision.gameObject); // 총알 삭제
        }
    }
}
