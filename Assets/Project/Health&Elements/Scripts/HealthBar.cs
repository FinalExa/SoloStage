using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = this.gameObject.GetComponent<Slider>();
    }

    private void Start()
    {
        slider.minValue = 0f;
    }

    public void SetMaxHPOnSlider(float maxHP)
    {
        slider.maxValue = maxHP;
        slider.value = maxHP;
    }
    public void UpdateHealthBar(float currentHP)
    {
        slider.value = currentHP;
    }
}
