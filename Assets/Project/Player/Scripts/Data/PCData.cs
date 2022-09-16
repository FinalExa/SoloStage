using UnityEngine;
using UnityEngine.Playables;

[CreateAssetMenu(fileName = "PCData", menuName = "ScriptableObjects/PCData", order = 1)]
public class PCData : ScriptableObject
{
    [Header("Health Section")]
    public float maxHP;
    [Header("Movement Section")]
    public float defaultMovementSpeed;
    [Header("Nectar Section")]
    public float maxNectar;
    public float nectarStopRegenCooldown;
    public float nectarRegenPerSecond;
    public float nectarInfusionPerSecondComsuption;
    [Header("Dodge Section")]
    public Vector3 defaultDirection;
    public string invulnerabilityTag;
    public float dodgeDuration;
    public float dodgeDistance;
    public float dodgeStopTime;
}
