using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    public PlayerHealth playerHealth; // PlayerHealth 스크립트를 가진 객체
    public Text healthText; // 체력을 표시할 UI 텍스트

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

        UpdateHealthText(); // UI 텍스트 업데이트
    }

    private void UpdateHealthText()
    {
        healthText.text = "Health: " + playerHealth.currentHealth.ToString(); // 텍스트 업데이트
    }

    private void Update()
    {
        if (playerHealth != null && playerHealth.currentHealth != int.Parse(healthText.text.Substring(7)))
        {
            UpdateHealthText(); // 체력이 변경되면 UI 텍스트 업데이트
        }
    }
}
