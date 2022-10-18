using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public string damageTag;
    public EnemyWeapon enemyWeapon;
    public Rotation rotation;
    public bool isAlerted;
    [HideInInspector] public GameObject playerTarget;
    [HideInInspector] public EnemyRotator enemyRotator;
    [HideInInspector] public EnemyCombo enemyCombo;
    [HideInInspector] public NavMeshAgent thisNavMeshAgent;
    private void Awake()
    {
        playerTarget = FindObjectOfType<PCController>().gameObject;
        enemyRotator = this.gameObject.GetComponent<EnemyRotator>();
        enemyCombo = this.gameObject.GetComponent<EnemyCombo>();
        thisNavMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        isAlerted = true;
        enemyWeapon.damageTag = damageTag;
        enemyWeapon.ReferencesSetup(damageTag, 0f);
    }
    private void OnDisable()
    {
        ReactionObject[] reactionObjects = this.gameObject.GetComponentsInChildren<ReactionObject>();
        foreach (ReactionObject reactionObject in reactionObjects) reactionObject.ReactionObjectEnd();
    }
}
