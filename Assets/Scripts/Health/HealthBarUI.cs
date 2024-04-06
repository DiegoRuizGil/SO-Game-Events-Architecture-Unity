using GameEvents;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _reduceSpeed = 1f;
    
    [Header("UI Dependencies")]
    [SerializeField] private Slider _slider;

    [Header("Events")]
    [SerializeField] private BoolEvent _onDeathEvent;

    private int _maxHealth;
    private float _sliderTarget = 1f;

    private bool _isDead;

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _sliderTarget, _reduceSpeed * Time.deltaTime);
        CheckDeathEvent();
    }

    public void SetMaxHealth(int maxHealth)
    {
        _maxHealth = maxHealth;
    }

    public void UpdateHealth(int currentHealth)
    {
        float healthPercentage = ((float)currentHealth) / _maxHealth;
        _sliderTarget = healthPercentage;
    }

    private void CheckDeathEvent()
    {
        if (_slider.value == 0 && !_isDead)
        {
            _isDead = true;
            if (_onDeathEvent != null)
            {
                _onDeathEvent.Raise(true);
            }
                
        }
        else if (_slider.value > 0 && _isDead)
        {
            _isDead = false;
            if (_onDeathEvent != null)
            {
                _onDeathEvent.Raise(false);
            }
        }
    }
}
