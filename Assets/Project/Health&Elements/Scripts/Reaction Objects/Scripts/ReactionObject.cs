using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionObject : MonoBehaviour
{
    private string damageTag;
    [SerializeField] private string reactionObjectName;
    [SerializeField] private float duration;
    [SerializeField] private ReactionOvertimeDamage reactionOvertimeDamage;
    private float durationTimer;

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
        durationTimer = duration;
        if (reactionOvertimeDamage.enabled) reactionOvertimeDamage.SetStartupValues(this, damageTag);
    }

    private void ExecuteReactionObjectOptions()
    {
        if (reactionOvertimeDamage.enabled) reactionOvertimeDamage.OvertimeDamage();
    }
    private void ReactionObjectDuration()
    {
        if (durationTimer > 0) durationTimer -= Time.deltaTime;
        else GameObject.Destroy(this.gameObject);
    }
}
