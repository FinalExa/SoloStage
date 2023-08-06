using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaGauge : MonoBehaviour
{
    private PCReferences pcReferences;
    private float maxStaminaGauge;
    private float currentStaminaGauge;
    private float regenCooldownTimer;
    private bool regenCooldown;
    private bool regenActive;
    [SerializeField] private Slider staminaGaugeSlider;

    private void Awake()
    {
        pcReferences = this.gameObject.GetComponent<PCReferences>();
    }

    private void Start()
    {
        StartupStaminaGauge();
    }

    private void StartupStaminaGauge()
    {
        maxStaminaGauge = pcReferences.pcData.maxStaminaGauge;
        currentStaminaGauge = maxStaminaGauge;
        staminaGaugeSlider.maxValue = maxStaminaGauge;
        staminaGaugeSlider.value = currentStaminaGauge;
    }

    private void Update()
    {
        RegenCooldown();
        Regen();
    }

    public void UpdateStaminaGaugeValue(float updateValue)
    {
        float staminaGaugeCheck = currentStaminaGauge;
        currentStaminaGauge = Mathf.Clamp(currentStaminaGauge + updateValue, 0f, maxStaminaGauge);
        staminaGaugeSlider.value = currentStaminaGauge;
        if (currentStaminaGauge < maxStaminaGauge && !regenCooldown && currentStaminaGauge <= staminaGaugeCheck)
        {
            regenCooldown = true;
            regenCooldownTimer = pcReferences.pcData.staminaRegenCooldown;
        }
    }

    private void RegenCooldown()
    {
        if (regenCooldown)
        {
            if (regenCooldownTimer > 0) regenCooldownTimer -= Time.deltaTime;
            else
            {
                regenCooldown = false;
                regenActive = true;
            }
        }
    }

    private void Regen()
    {
        if (!regenCooldown && regenActive)
        {
            UpdateStaminaGaugeValue(pcReferences.pcData.staminaRegenPerSecond * Time.deltaTime);
        }
    }

    public float GetCurrentStamina()
    {
        return currentStaminaGauge;
    }
}
