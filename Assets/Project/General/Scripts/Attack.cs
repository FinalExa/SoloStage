using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [HideInInspector] public string whoToDamage;
    [HideInInspector] public Reaction.Element infusedElement;
    [HideInInspector] public float elementDuration;
    [HideInInspector] public bool canApplyElement;

    protected Reaction reaction;
    protected Collider otherCollider;
    protected AttackCheck otherAttackCheck;

    protected virtual void Awake()
    {
        reaction = FindObjectOfType<Reaction>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GetOtherReferences(other);
        SendAttackData();
    }
    public virtual void InitializeAttack(string damageTag, float sourceElementDuration)
    {
        whoToDamage = damageTag;
        elementDuration = sourceElementDuration;
    }

    protected virtual void GetOtherReferences(Collider other)
    {
        otherCollider = other;
        otherAttackCheck = other.gameObject.GetComponent<AttackCheck>();
    }
    protected virtual void SendAttackData()
    {
        if (otherAttackCheck != null)
        {
            if (otherCollider.CompareTag(whoToDamage)) otherAttackCheck.CheckReceivedAttackData(whoToDamage, canApplyElement, infusedElement, elementDuration, false, 0f);
            else if (otherCollider.CompareTag("Invulnerable")) otherAttackCheck.CheckReceivedAttackData(whoToDamage, canApplyElement, infusedElement, elementDuration, false, 0f);
        }
    }
}
