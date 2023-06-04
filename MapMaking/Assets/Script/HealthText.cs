using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    public PlayerHealth playerHealth; // PlayerHealth ��ũ��Ʈ�� ���� ��ü
    public Text healthText; // ü���� ǥ���� UI �ؽ�Ʈ

    private void Start()
    {
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth script is not assigned!");
            return;
        }

        if (healthText == null)
        {
            Debug.LogError("Health text is not assigned!");
            return;
        }

        UpdateHealthText(); // UI �ؽ�Ʈ ������Ʈ
    }

    private void UpdateHealthText()
    {
        healthText.text = "Health: " + playerHealth.currentHealth.ToString(); // �ؽ�Ʈ ������Ʈ
    }

    private void Update()
    {
        if (playerHealth != null && playerHealth.currentHealth != int.Parse(healthText.text.Substring(7)))
        {
            UpdateHealthText(); // ü���� ����Ǹ� UI �ؽ�Ʈ ������Ʈ
        }
    }
}
