using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHP;
    public float maxHP;
    [SerializeField] private bool autoSet;
    [SerializeField] private HealthBar healthBar;

    private void Start()
    {
        if (autoSet && healthBar != null) healthBar.SetMaxHPOnSlider(maxHP);
    }

    public virtual void SetHPStartup(float givenMaxHP)
    {
        maxHP = givenMaxHP;
        currentHP = maxHP;
        if (healthBar != null) healthBar.SetMaxHPOnSlider(maxHP);
    }

    public virtual void HealthAddValue(float healthToAdd)
    {
        currentHP += healthToAdd;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        if (currentHP <= 0) this.gameObject.SetActive(false);
        else if (healthBar != null) healthBar.UpdateHealthBar(currentHP);
    }
}
