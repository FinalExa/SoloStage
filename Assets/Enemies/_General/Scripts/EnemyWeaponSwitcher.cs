using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponSwitcher : MonoBehaviour
{
    protected EnemyController enemyController;
    [HideInInspector] public Weapon weapon;
    [SerializeField] protected GameObject enemyWeaponsSlot;

    private void Awake()
    {
        Startup();
    }
    private void Start()
    {
        SetEnemyWeapon();
    }

    protected virtual void Startup()
    {
        enemyController = this.gameObject.GetComponent<EnemyController>();
        GenerateEnemyWeapons();
    }
    protected virtual void GenerateEnemyWeapons()
    {
        weapon = GenerateWeapon(enemyController.enemyData.weapon);
    }
    protected Weapon GenerateWeapon(Weapon weaponRef)
    {
        return Instantiate(weaponRef, enemyWeaponsSlot.transform);
    }
    public virtual void SetEnemyWeapon()
    {
        SetEnemyWeapon(weapon);
    }
    protected void SetEnemyWeapon(Weapon weaponToSet)
    {
        enemyController.currentWeapon = weaponToSet;
        enemyController.enemyCombo.SetWeapon(enemyController.currentWeapon);
    }
}
