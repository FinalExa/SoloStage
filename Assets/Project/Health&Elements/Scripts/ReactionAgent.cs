using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionAgent : MonoBehaviour
{
    public Element appliedElement;
    private float internalCooldown;
    public bool InCooldown { get; private set; }
    private void Update()
    {
        ReactionICD();
    }

    public void StartReactionICD(float ICD)
    {
        internalCooldown = ICD;
        InCooldown = true;
    }
    private void ReactionICD()
    {
        if (InCooldown)
        {
            if (internalCooldown > 0) internalCooldown -= Time.deltaTime;
            else InCooldown = false;
        }
    }
}
