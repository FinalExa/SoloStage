using UnityEngine;

[CreateAssetMenu(fileName = "PCData", menuName = "ScriptableObjects/PCData", order = 1)]
public class PCData : ScriptableObject
{
    [Header("Health Section")]
    public float maxHP;
    [Header("Movement Section")]
    public float defaultMovementSpeed;
    [Header("Stamina Section")]
    public float maxStaminaGauge;
    public float staminaRegenCooldown;
    public float staminaRegenPerSecond;
    [Header("Element Gauge Section")]
    public float maxElementGauge;
    public float elementGaugeRegenCooldown;
    public float elementGaugeRegenPerSecond;
    public float elementGaugeDrainPerSecond;
    [Header("Dodge Section")]
    public Vector3 defaultDirection;
    public string invulnerabilityTag;
    public float dodgeInvulnerabilityStart;
    public float dodgeInvulnerabilityEnd;
    public float dodgeDuration;
    public float dodgeDistance;
    public float dodgeEndCooldown;
    public float dodgeStaminaCost;
    public float dodgeApplicationCost;
}
