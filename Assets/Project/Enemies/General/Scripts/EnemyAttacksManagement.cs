using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyAttacksManagement : MonoBehaviour
{
    private EnemyController enemyController;
    [SerializeField] private GameObject attackSlot;
    [SerializeField] private EnemyWeapon[] enemyAttacks;
    public List<EnemyWeapon> orderedEnemyAttacks;

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
        foreach (EnemyWeapon attack in enemyAttacks) Instantiate(attack, attackSlot.transform);
        foreach (EnemyWeapon weapon in attackSlot.transform.GetComponentsInChildren<EnemyWeapon>())
        {
            orderedEnemyAttacks.Add(weapon);
            weapon.ReferencesSetup(enemyController.damageTag, weapon.elementDuration);
            weapon.gameObject.SetActive(false);
        }
        orderedEnemyAttacks = enemyAttacks.OrderBy(x => x.GetComponent<EnemyWeapon>().performableRange).ToList();
        SetEnemyWeapon(orderedEnemyAttacks.Count - 1);
    }

    private void SetEnemyWeapon(int index)
    {
        enemyController.enemyWeapon = orderedEnemyAttacks[index];
        enemyController.enemyCombo.SetWeapon(enemyController.enemyWeapon);
    }
}
