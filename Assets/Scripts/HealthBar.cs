using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : HealthView
{
    protected Slider Slider;

    private void Awake()
    {
        InitializingSlider();
    }

    protected void InitializingSlider()
    {
        Slider = GetComponent<Slider>();
        Slider.maxValue = Health.MaxHealth;
        Slider.value = Slider.maxValue;
    }

    protected override void ChangeValue(int newValue)
    {
        Slider.value = newValue;
    }
}
