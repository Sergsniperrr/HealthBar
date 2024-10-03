using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxHealth = 100;

    public event Action<int> ChangeValue;

    private int _currentHealth;

    public bool IsAlive => _currentHealth > 0;
    public int MaxHealth => _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (IsAlive && damage > 0)
        {
            _currentHealth -= damage;

            if (_currentHealth < 0)
                _currentHealth = 0;

            ChangeValue?.Invoke(_currentHealth);
        }
    }

    public void Heal(int healingAmount)
    {
        if (IsAlive && healingAmount > 0)
        {
            _currentHealth += healingAmount;

            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;

            ChangeValue?.Invoke(_currentHealth);
        }
    }
}
