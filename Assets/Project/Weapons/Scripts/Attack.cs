using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Weapon thisWeapon;
    public string whoToDamage;
    public Element infusedElement;
    public bool canApplyElement;

    private void OnTriggerStay(Collider other)
    {
        Health otherHealth = other.gameObject.GetComponent<Health>();
        if (otherHealth != null && canApplyElement)
        {
            if (otherHealth.appliedElement.element == Element.Elements.NONE) otherHealth.appliedElement.element = infusedElement.element;
            else if (otherHealth.appliedElement.element != infusedElement.element)
            {
                print("Reaction");
                otherHealth.HealthAddValue(-50);
                otherHealth.appliedElement.element = Element.Elements.NONE;
            }
        }
        if (otherHealth != null && other.CompareTag(whoToDamage) && !thisWeapon.hitTargets.Contains(otherHealth))
        {
            otherHealth.HealthAddValue(-thisWeapon.currentDamage);
            thisWeapon.hitTargets.Add(otherHealth);
        }
    }
}
