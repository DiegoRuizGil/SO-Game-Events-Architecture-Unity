using UnityEngine;
using GameEvents;

public class HealthController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _maxHealth = 100;
    
    [Header("Events")]
    [SerializeField] private IntEvent _onHealthUpdated;
    [SerializeField] private IntEvent _onMaxHealthInitialize;

    private Health _health;
    
    private void Awake()
    {
        _health = new Health(_maxHealth, _onHealthUpdated);
    }

    private void Start()
    {
        if (_onMaxHealthInitialize != null)
            _onMaxHealthInitialize.Raise(_maxHealth);
    }

    public void Damage(int amount)
    {
        _health.Damage(amount);
    }

    public void Recover(int amount)
    {
        _health.Recover(amount);
    }
}
