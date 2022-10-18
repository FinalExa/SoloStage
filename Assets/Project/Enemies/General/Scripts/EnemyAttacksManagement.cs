using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyAttacksManagement : MonoBehaviour
{
    private EnemyController enemyController;
    [SerializeField] private GameObject attackSlot;
    [SerializeField] private EnemyWeapon[] enemyAttacks;
    private List<EnemyWeapon> orderedEnemyAttacks;
    private int attacksCount;
    private int lockedIndex;

    private void Awake()
    {
        enemyController = this.gameObject.GetComponent<EnemyController>();
    }

    private void Start()
    {
        SetupAttacksList();
    }
    private void Update()
    {
        SearchForNextAttack();
    }
    private void SetupAttacksList()
    {
        orderedEnemyAttacks = new List<EnemyWeapon>();
        foreach (EnemyWeapon weapon in enemyAttacks)
        {
            orderedEnemyAttacks.Add(weapon);
            weapon.ReferencesSetup(enemyController.damageTag, weapon.elementDuration);
            weapon.gameObject.SetActive(false);
        }
        orderedEnemyAttacks = enemyAttacks.OrderBy(x => x.GetComponent<EnemyWeapon>().performableRange).ToList();
        attacksCount = orderedEnemyAttacks.Count();
        SetEnemyWeapon(orderedEnemyAttacks.Count - 1);
    }

    private void SetEnemyWeapon(int index)
    {
        enemyController.enemyWeapon = orderedEnemyAttacks[index];
        enemyController.enemyWeapon.gameObject.SetActive(true);
        enemyController.enemyCombo.SetWeapon(enemyController.enemyWeapon);
        lockedIndex = index;
    }

    private void SearchForNextAttack()
    {
        if (!enemyController.enemyCombo.isInCombo && attacksCount > 1 && orderedEnemyAttacks.IndexOf(enemyController.enemyWeapon) == lockedIndex)
        {
            float distance = Vector3.Distance(this.transform.position, enemyController.playerTarget.transform.position);
            bool found = false;
            for (int i = 0; i < attacksCount; i++)
            {
                if (i != lockedIndex && distance <= orderedEnemyAttacks[i].performableRange)
                {
                    SetEnemyWeapon(i);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                if (lockedIndex == attacksCount - 1) SetEnemyWeapon(attacksCount - 2);
                else SetEnemyWeapon(attacksCount - 1);
            }
        }
    }
}
