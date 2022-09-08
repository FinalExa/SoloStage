using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCHealth : Health
{
    public override void HealthAddValue(float healthToAdd)
    {
        currentHealth += healthToAdd;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHP);
    }
}
