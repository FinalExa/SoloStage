using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [HideInInspector] public List<AttackReceived.GameTargets> possibleTargets;
    //[HideInInspector] public Reaction.Element infusedElement;
    [HideInInspector] public float elementDuration;
    [HideInInspector] public bool canApplyElement;

    protected Reaction reaction;
    protected AttackReceived attackReceived;

    protected virtual void Awake()
    {
        reaction = FindObjectOfType<Reaction>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GetOtherReferences(other);
        if (attackReceived != null) Damage(other.tag);
    }

    protected virtual void GetOtherReferences(Collider other)
    {
        attackReceived = other.gameObject.GetComponent<AttackReceived>();
    }

    protected virtual void Damage(string receivedTag)
    {
        return;
    }
}
