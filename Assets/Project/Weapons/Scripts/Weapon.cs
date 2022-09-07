using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Weapon : MonoBehaviour
{
    public string weaponName;
    public float comboCancelTime;
    public float comboEndDelay;
    public WeaponAttack[] weaponAttacks;
}
