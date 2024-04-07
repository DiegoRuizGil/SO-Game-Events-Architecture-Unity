using GameEvents;
using UnityEngine;

public class Health
{
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    private IntEvent _onHealthUpdated;

    public Health(int maxHealth, IntEvent onHealthUpdated)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        _onHealthUpdated = onHealthUpdated;
    }

    private void UpdateHealth(int amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);
        
        if (_onHealthUpdated != null)
            _onHealthUpdated.Raise(CurrentHealth);
    }

    public void Damage(int amount)
    {
        UpdateHealth(-amount);
    }

    public void Recover(int amount)
    {
        UpdateHealth(amount);
    }
}