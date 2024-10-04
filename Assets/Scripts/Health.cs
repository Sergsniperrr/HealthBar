using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxValue = 100;

    private int _currentValue;

    public event Action<int> ChangeValue;

    public int MaxValue => _maxValue;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _currentValue -= damage;

            if (_currentValue < 0)
                _currentValue = 0;

            ChangeValue?.Invoke(_currentValue);
        }
    }

    public void TakeHealing(int healingAmount)
    {
        if (healingAmount > 0)
        {
            _currentValue += healingAmount;

            if (_currentValue > _maxValue)
                _currentValue = _maxValue;

            ChangeValue?.Invoke(_currentValue);
        }
    }
}
