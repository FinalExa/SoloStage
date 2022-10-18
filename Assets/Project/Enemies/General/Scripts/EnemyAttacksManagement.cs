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

    private void Awake()
    {
        enemyController = this.gameObject.GetComponent<EnemyController>();
    }

    private void Start()
    {
        SetupAttacksList();
    }

    private void SetupAttacksList()
    {
        orderedEnemyAttacks = new List<EnemyWeapon>();
        foreach (EnemyWeapon attack in enemyAttacks)
        {
            EnemyWeapon weapon = Instantiate(attack, attackSlot.transform);
            orderedEnemyAttacks.Add(weapon);
            weapon.ReferencesSetup(enemyController.damageTag, weapon.elementDuration);
        }
        orderedEnemyAttacks = enemyAttacks.OrderBy(x => x.GetComponent<EnemyWeapon>().performableRange).ToList();
        enemyController.enemyWeapon = orderedEnemyAttacks[orderedEnemyAttacks.Count - 1];
    }
}
