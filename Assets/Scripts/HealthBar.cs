using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health Health;

    protected Slider Slider;

    private void Awake()
    {
        InitializingSlider();
    }

    private void OnEnable()
    {
        Health.ChangeValue += ChangeValue;
    }

    private void OnDisable()
    {
        Health.ChangeValue -= ChangeValue;
    }

    protected void InitializingSlider()
    {
        Slider = GetComponent<Slider>();
        Slider.maxValue = Health.MaxHealth;
        Slider.value = Slider.maxValue;
    }

    protected virtual void ChangeValue(int newValue)
    {
        Slider.value = newValue;
    }
}
