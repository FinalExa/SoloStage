using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private string whoToDamage;
    [SerializeField] private Weapon enemyWeapon;
    public float attackDistance;
    public GameObject playerTarget;
    public EnemyCombo enemyCombo;
    public NavMeshAgent thisNavMeshAgent;
    private void Awake()
    {
        playerTarget = FindObjectOfType<PCController>().gameObject;
        enemyCombo = this.gameObject.GetComponent<EnemyCombo>();
        thisNavMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        enemyWeapon.damageTag = whoToDamage;
        enemyCombo.SetWeapon(enemyWeapon);
    }
}
