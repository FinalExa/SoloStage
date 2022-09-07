using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Weapon : MonoBehaviour
{
    public string weaponName;
    public float weaponCancelComboTime;
    public WeaponAttack[] weaponAttacks;
}
