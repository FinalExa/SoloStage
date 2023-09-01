using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PCHealth : Health
{
    private PCReferences pcReferences;
    [SerializeField] private Slider healthBarSlider;

    private void Awake()
    {
        pcReferences = this.gameObject.GetComponent<PCReferences>();
    }

    protected override void Start()
    {
        base.Start();
        SetHPStartup(pcReferences.pcData.maxHP);
    }
    public override void HealthAddValue(float healthToAdd, bool feedbackActive)
    {
        base.HealthAddValue(healthToAdd, feedbackActive);
        healthBarSlider.value = currentHP;
    }

    public override void OnDeath()
    {
        if (uxOnDeath.hasSound) uxOnDeath.sound.PlayAudio();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public override void OnHitReceived(bool feedbackActive)
    {
        base.OnHitReceived(feedbackActive);
    }

    public override void SetHPStartup(float givenMaxHP)
    {
        base.SetHPStartup(givenMaxHP);
        healthBarSlider.maxValue = maxHP;
        healthBarSlider.minValue = 0f;
        healthBarSlider.value = currentHP;
    }
}
