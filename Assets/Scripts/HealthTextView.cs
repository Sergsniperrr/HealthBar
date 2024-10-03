using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthTextView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TextMeshProUGUI _text;
    private string _separator = "/";

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = _health.MaxHealth + _separator + _health.MaxHealth;
    }

    private void OnEnable()
    {
        _health.ChangeValue += ChangeValue;
    }

    private void OnDisable()
    {
        _health.ChangeValue -= ChangeValue;
    }

    private void ChangeValue(int newValue)
    {
        _text.text = newValue + _separator + _health.MaxHealth;
    }
}
