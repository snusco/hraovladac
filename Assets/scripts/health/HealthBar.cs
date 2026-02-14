using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        // Nastaví èierne pozadie (total) na 100%
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        // Úprava pre tvoje JEDNO srdieèko:
        // Ak máš 3 životy, delíme to 3f, aby fillAmount fungoval správne (0 až 1)
        currentHealthBar.fillAmount = playerHealth.currentHealth / 3f;
    }
}