using TMPro;
using UnityEngine;

public class HealthTextUI : MonoBehaviour
{
    [Header("UI Dependencies")]
    [SerializeField] private TextMeshProUGUI _healtText;

    private int _maxHealth;

    public void SetMaxHealth(int maxHealth)
    {
        _maxHealth = maxHealth;
        SetHealthText(_maxHealth);
    }
    
    public void UpdateHealth(int currentHealth)
    {
        SetHealthText(currentHealth);
    }

    private void SetHealthText(int amount)
    {
        _healtText.text = $"{amount}/{_maxHealth}";
    }
}
