using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PCHealth : Health
{
    private PCReferences pcReferences;
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
    }
    public override void OnDeath(bool skipOnDeathInteraction)
    {
        if (uxOnDeath.hasSound) uxOnDeath.sound.PlayAudio();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
