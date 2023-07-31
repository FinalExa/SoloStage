using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElementGauge : MonoBehaviour
{
    [SerializeField] private Slider elementGaugeSlider;
    [SerializeField] private TMP_Text elementText;
    [SerializeField] private TMP_Text infusedText;
    private PCReferences pcReferences;
    private float maxElementGauge;
    private float currentElementGauge;
    private float depletedGaugeCooldown;
    private bool drainActive;
    private bool regenCooldown;
    public enum ElementTypes { NONE, FIRE, WATER, PLANT, WIND, GROUND, THUNDER, GRAVITY, FROST, DARKNESS, LIGHT }

    private void Awake()
    {
        pcReferences = this.gameObject.GetComponent<PCReferences>();
    }

    private void Start()
    {
        elementText.gameObject.SetActive(false);
        infusedText.gameObject.SetActive(false);
        StartupElementGauge();
    }

    private void Update()
    {
        OnInputReceived();
        Drain();
        RegenCooldown();
        Regen();
    }

    private void StartupElementGauge()
    {
        maxElementGauge = pcReferences.pcData.maxElementGauge;
        currentElementGauge = maxElementGauge;
        elementGaugeSlider.maxValue = maxElementGauge;
        elementGaugeSlider.minValue = 0f;
        elementGaugeSlider.value = currentElementGauge;
    }

    private void UpdateElementGaugeValue(float updateValue)
    {
        currentElementGauge = Mathf.Clamp(currentElementGauge + updateValue, 0f, maxElementGauge);
        elementGaugeSlider.value = currentElementGauge;
    }

    private void OnInputReceived()
    {
        if (pcReferences.pcInputs.InfuseInput && !regenCooldown)
        {
            drainActive = !drainActive;
            if (!drainActive)
            {
                SetupRegenCooldown();
                pcReferences.infusion.infused = false;
                elementText.gameObject.SetActive(false);
                infusedText.gameObject.SetActive(false);
            }
            else
            {
                pcReferences.infusion.infused = true;
                elementText.gameObject.SetActive(true);
                elementText.text = pcReferences.infusion.GetCurrentElement().ToString();
                infusedText.gameObject.SetActive(true);
            }
        }
    }

    private void Drain()
    {
        if (drainActive)
        {
            UpdateElementGaugeValue(-pcReferences.pcData.elementGaugeDrainPerSecond * Time.deltaTime);
            if (currentElementGauge == 0)
            {
                drainActive = false;
                SetupRegenCooldown();
            }
        }
    }

    private void SetupRegenCooldown()
    {
        regenCooldown = true;
        depletedGaugeCooldown = pcReferences.pcData.elementGaugeRegenCooldown;
    }

    private void RegenCooldown()
    {
        if (regenCooldown)
        {
            if (depletedGaugeCooldown > 0) depletedGaugeCooldown -= Time.deltaTime;
            else regenCooldown = false;
        }
    }

    private void Regen()
    {
        if (!regenCooldown && !drainActive)
        {
            UpdateElementGaugeValue(pcReferences.pcData.elementGaugeRegenPerSecond * Time.deltaTime);
        }
    }
}
