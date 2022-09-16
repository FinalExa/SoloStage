using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PCCombo : Combo
{
    private PCController pcController;
    private void Awake()
    {
        pcController = this.gameObject.GetComponent<PCController>();
    }

    public override void Infusion(WeaponAttack.WeaponAttackHitboxSequence hitboxToCheck)
    {
        if (pcController.pcReferences.pcNectar.isInfused)
        {
            hitboxToCheck.attackRef.infusedElement = pcController.pcReferences.pcElementEquip.equippedElement;
            hitboxToCheck.attackRef.canApplyElement = true;
        }
    }
}
