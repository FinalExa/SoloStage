using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCController : MonoBehaviour
{
    [HideInInspector] public string curState;
    [HideInInspector] public PCReferences pcReferences;
    [HideInInspector] public float actualSpeed;
    [SerializeField] private string whoToDamage;
    public Rotation rotation;
    public GameObject rotator;
    public Weapon equippedWeapon;
    [HideInInspector] public bool dodgeInCooldown;
    private float dodgeCooldownTimer;
    [HideInInspector] public float receivedDamage;


    private void Awake()
    {
        pcReferences = this.gameObject.GetComponent<PCReferences>();
    }

    private void Start()
    {
        pcReferences.health.SetHPStartup(pcReferences.pcData.maxHP);
        equippedWeapon.damageTag = whoToDamage;
    }
    private void Update()
    {
        DodgeCooldown();
        if (receivedDamage > 0) receivedDamage--;
    }

    public void SetDodgeEndCooldown(float endCooldown)
    {
        dodgeCooldownTimer = endCooldown;
        dodgeInCooldown = true;
    }

    public void DodgeCooldown()
    {
        if (dodgeInCooldown)
        {
            if (dodgeCooldownTimer > 0) dodgeCooldownTimer -= Time.deltaTime;
            else dodgeInCooldown = false;
        }
    }
}
