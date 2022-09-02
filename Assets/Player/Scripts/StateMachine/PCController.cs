using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCController : Controller
{
    [HideInInspector] public string curState;
    [HideInInspector] public PCReferences pcReferences;
    [HideInInspector] public float actualSpeed;
    [SerializeField] private string whoToDamage;
    private bool regenWaitBool;
    private float regenWaitTimer;
    private bool regenBool;

    private void Start()
    {
        actualHealth = pcReferences.pcData.maxHP;
        regenWaitTimer = pcReferences.pcData.healthRegenMaxTimer;
        SetupAttacks();
    }

    private void Awake()
    {
        pcReferences = this.gameObject.GetComponent<PCReferences>();
    }

    private void FixedUpdate()
    {
        //if (regenWaitBool) RegenWait();
        //if (regenBool) Regen();
    }

    public override void HealthAddValue(float valueToAdd)
    {
        actualHealth += valueToAdd;
        actualHealth = Mathf.Clamp(actualHealth, 0, pcReferences.pcData.maxHP);
        //RegenCheck();
    }


    private void RegenCheck()
    {
        if (actualHealth < pcReferences.pcData.maxHP && !regenWaitBool)
        {
            regenWaitBool = true;
            if (regenBool) regenBool = false;
            regenWaitTimer = pcReferences.pcData.healthRegenMaxTimer;
        }
    }

    private void RegenWait()
    {
        if (regenWaitTimer > 0) regenWaitTimer -= Time.fixedDeltaTime;
        else
        {
            regenWaitBool = false;
            regenBool = true;
        }
    }

    private void Regen()
    {
        float valueToRegen = pcReferences.pcData.healthRegenRatePerSecond * Time.fixedDeltaTime;
        actualHealth += valueToRegen;
        actualHealth = Mathf.Clamp(actualHealth, 0, pcReferences.pcData.maxHP);
        if (actualHealth == pcReferences.pcData.maxHP) regenBool = false;
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
