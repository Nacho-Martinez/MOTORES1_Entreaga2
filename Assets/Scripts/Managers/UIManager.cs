using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    
    private void OnEnable()
    {
        EventManager.Instance.OnPlayerDamage += UpdateHealthBar;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnPlayerDamage -= UpdateHealthBar;
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
        healthBar.color = Color.Lerp(Color.darkRed, Color.green, currentHealth / maxHealth);
    }
}
