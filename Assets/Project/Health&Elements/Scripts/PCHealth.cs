using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCHealth : Health
{
    public override void HealthAddValue(float healthToAdd)
    {
        currentHP += healthToAdd;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    }
}
