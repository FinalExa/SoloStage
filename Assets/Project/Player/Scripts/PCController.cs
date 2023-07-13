using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCController : MonoBehaviour
{
    [HideInInspector] public string curState;
    [HideInInspector] public PCReferences pcReferences;
    [HideInInspector] public float actualSpeed;
    public Rotation rotation;
    public GameObject rotator;
    [HideInInspector] public Vector3 lastDirection;
    public Weapon equippedWeapon;
    public float weaponElementDuration;
    [HideInInspector] public bool dodgeInCooldown;
    private float dodgeCooldownTimer;
    public Attack dodgeHitbox;
    public float dodgeHitboxElementDuration;
    //[SerializeField] private Reaction.Element dodgeElement;
    [HideInInspector] public float receivedDamage;
    [SerializeField] private GameObject tempDodgeInterrupted;
    [SerializeField] private float tempDodgeInterruptedDuration;
    private bool tempDodgeInterruptedActive;
    [HideInInspector] public bool lockDodgeSpam;
    private float tempDodgeInterruptedTimer;
    public Skill skill;
    [HideInInspector] public bool skillActive;


    private void Awake()
    {
        pcReferences = this.gameObject.GetComponent<PCReferences>();
    }

    private void Start()
    {
        tempDodgeInterrupted.SetActive(false);
        pcReferences.health.SetHPStartup(pcReferences.pcData.maxHP);
        dodgeHitbox.canApplyElement = true;
        //dodgeHitbox.infusedElement = dodgeElement;
        dodgeHitbox.gameObject.SetActive(false);
        dodgeHitbox.elementDuration = dodgeHitboxElementDuration;
        lastDirection = new Vector3(0f, 0f, 1f).normalized;
    }
    private void Update()
    {
        DodgeCooldown();
        DodgeInterruptedFeedback();
        DodgeSpam();
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
    private void DodgeSpam()
    {
        if (lockDodgeSpam && !pcReferences.inputs.DodgeInput) lockDodgeSpam = false;
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

    /*public void LaunchSkill()
    {
        skill.gameObject.SetActive(true);
        skill.SkillLaunch();
    }*/
}
