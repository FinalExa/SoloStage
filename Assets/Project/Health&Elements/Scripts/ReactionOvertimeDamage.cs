using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ReactionOvertimeDamage
{
    public bool enabled;
    public float baseValue;
    public float multiplier;
    public bool firstHitOn;
    public float timeBetweenHits;
    private bool firstHitDone;
    private float timer;
    private float damage;
    private Health targetHealth;
    private string whoToDamage;
    public void SetStartupValues(Health health, string damageTag)
    {
        targetHealth = health;
        whoToDamage = damageTag;
        timer = timeBetweenHits;
        damage = baseValue + (multiplier * 0f);
        firstHitDone = false;
    }

    public void OvertimeDamage()
    {
        if (firstHitOn && !firstHitDone)
        {
            DealDamage();
            firstHitDone = true;
        }
        if (timer > 0) timer -= Time.deltaTime;
        else
        {
            DealDamage();
            timer = timeBetweenHits;
        }
    }

    private void DealDamage()
    {
        targetHealth.HealthAddValue(-damage);
    }
}
