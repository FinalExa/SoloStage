using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Weapon thisWeapon;
    public string whoToDamage;

    private void OnTriggerStay(Collider other)
    {
        Health otherHealth = other.gameObject.GetComponent<Health>();
        if (otherHealth != null && other.CompareTag(whoToDamage) && !thisWeapon.hitTargets.Contains(otherHealth))
        {
            otherHealth.HealthAddValue(-thisWeapon.currentDamage);
            thisWeapon.hitTargets.Add(otherHealth);
        }
    }
}
