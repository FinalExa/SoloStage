using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Rotation rotation;
    public EnemyData enemyData;
    [HideInInspector] public Weapon currentWeapon;
    public bool isAlerted;
    [HideInInspector] public PCController playerRef;
    [HideInInspector] public GameObject playerTarget;
    [HideInInspector] public NavMeshAgent thisNavMeshAgent;
    [HideInInspector] public EnemyCombo enemyCombo;
    [HideInInspector] public bool AttackDone { get; set; }
    [HideInInspector] public AttackReceived attackReceived;

    protected virtual void Awake()
    {
        playerRef = FindObjectOfType<PCController>();
        playerTarget = playerRef.gameObject;
        thisNavMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        enemyCombo = this.gameObject.GetComponent<EnemyCombo>();
        attackReceived = this.gameObject.GetComponent<AttackReceived>();
    }
    public virtual void LightStateUpdate()
    {
        return;
    }
}
