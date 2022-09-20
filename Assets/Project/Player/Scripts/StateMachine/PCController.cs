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
    [SerializeField] private GameObject tempDodgeInterrupted;
    [SerializeField] private float tempDodgeInterruptedDuration;
    private bool tempDodgeInterruptedActive;
    private float tempDodgeInterruptedTimer;
    [SerializeField] private Skill skill;
    [HideInInspector] public bool skillActive;


    private void Awake()
    {
        pcReferences = this.gameObject.GetComponent<PCReferences>();
    }

    private void Start()
    {
        tempDodgeInterrupted.SetActive(false);
        pcReferences.health.SetHPStartup(pcReferences.pcData.maxHP);
        equippedWeapon.damageTag = whoToDamage;
        skill.SkillSetup(whoToDamage);
        skill.gameObject.SetActive(false);
    }
    private void Update()
    {
        DodgeCooldown();
        DodgeInterruptedFeedback();
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

    public void DodgeInterruptedFeedbackSet()
    {
        tempDodgeInterrupted.SetActive(true);
        tempDodgeInterruptedTimer = tempDodgeInterruptedDuration;
        tempDodgeInterruptedActive = true;
    }

    private void DodgeInterruptedFeedback()
    {
        if (tempDodgeInterruptedActive)
        {
            if (tempDodgeInterruptedTimer > 0) tempDodgeInterruptedTimer -= Time.deltaTime;
            else
            {
                tempDodgeInterrupted.SetActive(false);
                tempDodgeInterruptedActive = false;
            }
        }
    }

    public void LaunchSkill()
    {
        skill.gameObject.SetActive(true);
        skill.SkillLaunch();
    }
}
