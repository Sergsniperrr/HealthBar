using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarSmooth : HealthBar
{
    private float _numberHitPointsBeforeDelay = 1f;
    private float _delay = 0.02f;
    private WaitForSeconds _waitForChangeValue;
    private Coroutine _coroutine;

    private void Awake()
    {
        InitializingSlider();
        _waitForChangeValue = new WaitForSeconds(_delay);
    }

    protected override void ChangeValue(int newValue)
    {
        if (_coroutine != null)
            StopAllCoroutines();

        _coroutine = StartCoroutine(SmoothChangeValue(newValue));
    }

    private IEnumerator SmoothChangeValue(int newValue)
    {
        while (Slider.value != newValue)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, newValue, _numberHitPointsBeforeDelay);

            yield return _waitForChangeValue;
        }
    }
}
