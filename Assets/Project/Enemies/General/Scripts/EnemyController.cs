using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private string whoToDamage;
    [SerializeField] private Weapon enemyWeapon;
    private EnemyCombo enemyCombo;
    private void Awake()
    {
        enemyCombo = this.gameObject.GetComponent<EnemyCombo>();
    }
    private void Start()
    {
        enemyWeapon.damageTag = whoToDamage;
        enemyCombo.SetWeapon(enemyWeapon);
    }
}
