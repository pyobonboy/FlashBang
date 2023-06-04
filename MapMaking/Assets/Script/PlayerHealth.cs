using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // �ִ� ü��
    public int currentHealth; // ���� ü��

    void Start()
    {
        currentHealth = maxHealth; // �ִ� ü������ �ʱ�ȭ
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount; // ü�� ����
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // ü���� �ִ� ü���� ���� �ʵ��� Ŭ����
        if (currentHealth <= 0)
        {
            Die(); // ü���� 0 ������ ��� ��� ó��
        }
    }

    void Die()
    {
        Debug.Log("ĳ���� ���");
        // ��� ó���� ���� �߰� ������ �����ϼ���.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            ModifyHealth(-10); // ü���� 10 ���ҽ�Ŵ

            Destroy(collision.gameObject); // �Ѿ� ����
        }
    }
}
