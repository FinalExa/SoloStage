using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReactionObject : MonoBehaviour
{
    private string damageTag;
    [SerializeField] private string reactionObjectName;
    [SerializeField] private float duration;
    [SerializeField] private bool isObstacle;
    [SerializeField] private ReactionOvertimeDamageObject reactionOvertimeDamageObject;
    private float durationTimer;
    private NavMeshObstacle obstacle;

    private void Awake()
    {
        obstacle = this.gameObject.GetComponent<NavMeshObstacle>();
    }

    private void Start()
    {
        StartupReactionObjectOptions();
    }

    private void Update()
    {
        ExecuteReactionObjectOptions();
        ReactionObjectDuration();
    }

    public void SetReactionObjectParameters(string _damageTag)
    {
        damageTag = _damageTag;
    }

    private void StartupReactionObjectOptions()
    {
        if (isObstacle) obstacle.enabled = true;
        durationTimer = duration;
        if (reactionOvertimeDamageObject.enabled) reactionOvertimeDamageObject.SetStartupValues(this, damageTag);
    }

    private void ExecuteReactionObjectOptions()
    {
        if (reactionOvertimeDamageObject.enabled) reactionOvertimeDamageObject.OvertimeDamage();
    }
    private void ReactionObjectDuration()
    {
        if (durationTimer > 0) durationTimer -= Time.deltaTime;
        else OnObjectDurationEnd();
    }

    private void OnObjectDurationEnd()
    {
        GameObject.Destroy(this.gameObject);
    }
}
