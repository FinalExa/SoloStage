using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private bool doesntTurnOffOnDeath;
    protected EnemyController enemyController;
    protected bool deathDone;

    protected virtual void Awake()
    {
        enemyController = this.gameObject.GetComponent<EnemyController>();
    }

    private void OnEnable()
    {
        SetHPStartup(enemyController.enemyData.maxHP);
        deathDone = false;
    }

    public override void OnDeath()
    {
        OnDeathSound();
        if (!doesntTurnOffOnDeath) SetEnemyDead();
    }
    private void SetEnemyDead()
    {
        if (!deathDone) this.gameObject.SetActive(false);
    }
}
