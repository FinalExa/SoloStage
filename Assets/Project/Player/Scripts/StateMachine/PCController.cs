using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCController : Controller
{
    [HideInInspector] public string curState;
    [HideInInspector] public PCReferences pcReferences;
    [HideInInspector] public float actualSpeed;
    [SerializeField] private string whoToDamage;
    public Weapon equippedWeapon;
    private void Start()
    {
        actualHealth = pcReferences.pcData.maxHP;
        SetupAttacks();
    }

    private void Awake()
    {
        pcReferences = this.gameObject.GetComponent<PCReferences>();
    }

    public override void HealthAddValue(float valueToAdd)
    {
        actualHealth += valueToAdd;
        actualHealth = Mathf.Clamp(actualHealth, 0, pcReferences.pcData.maxHP);
    }

    private void SetupAttacks()
    {
        foreach (Attack atk in pcReferences.attack)
        {
            atk.damageToDeal = pcReferences.pcData.comboDamage;
            atk.whoToDamage = whoToDamage;
        }
    }
}
