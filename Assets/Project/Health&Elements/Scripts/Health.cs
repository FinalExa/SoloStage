using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHP;

    public virtual void SetHPStartup(float givenMaxHP)
    {
        maxHP = givenMaxHP;
        currentHealth = maxHP;
    }

    public virtual void HealthAddValue(float healthToAdd)
    {
        currentHealth += healthToAdd;
        if (currentHealth <= 0) this.gameObject.SetActive(false);
    }
}
