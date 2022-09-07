using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Weapon thisWeapon;
    public string whoToDamage;

    private void OnTriggerStay(Collider other)
    {
        Controller otherController = other.gameObject.GetComponent<Controller>();
        if (otherController != null && other.CompareTag(whoToDamage) && !thisWeapon.hitTargets.Contains(otherController))
        {
            otherController.HealthAddValue(-thisWeapon.currentDamage);
            print(otherController.actualHealth);
            thisWeapon.hitTargets.Add(otherController);
        }
    }
}
