using UnityEngine;
using UnityEngine.UI;

public class Bunny : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField, Min(1)] private readonly int _maxHealth;
    [SerializeField] private Button _attackButton;
    [SerializeField] private Button _healButton;
    [SerializeField] private int _damagePerHit = 20;
    [SerializeField] private int _healthPerHeal = 20;

    private void OnEnable()
    {
        _attackButton.onClick.AddListener(TakeDamage);
        _healButton.onClick.AddListener(TakeHealing);
    }

    private void OnDisable()
    {
        _attackButton.onClick.RemoveListener(TakeDamage);
        _healButton.onClick.RemoveListener(TakeHealing);
    }

    private void TakeDamage()
    {
        _health.TakeDamage(_damagePerHit);
    }

    private void TakeHealing()
    {
        _health.Heal(_healthPerHeal);
    }
}
