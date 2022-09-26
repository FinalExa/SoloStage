using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCDodge : PCState
{
    private Vector3 direction;
    private string playerTag;
    private float dodgeTimer;
    private float dodgeSpeed;
    private float timeCount;
    private bool activateHitbox;
    private Inputs inputs;

    public PCDodge(PCStateMachine pcStateMachine) : base(pcStateMachine)
    {
    }

    public override void Start()
    {
        inputs = _pcStateMachine.pcController.pcReferences.inputs;
        DodgeDirection();
        if (!_pcStateMachine.pcController.dodgeInCooldown) DodgeSetup();
        else Transitions();
    }

    public override void FixedUpdate()
    {
        Dodge();
    }
    private void DodgeDirection()
    {
        if (inputs.MovementInput == Vector3.zero) direction = _pcStateMachine.pcController.lastDirection;
        else direction = new Vector3(inputs.MovementInput.z, 0f, inputs.MovementInput.x);
    }
    private void DodgeSetup()
    {
        PCData pcData = _pcStateMachine.pcController.pcReferences.pcData;
        playerTag = _pcStateMachine.gameObject.tag;
        dodgeTimer = pcData.dodgeDuration;
        dodgeSpeed = pcData.dodgeDistance / pcData.dodgeDuration;
        activateHitbox = false;
        timeCount = 0f;
    }
    private void SetHitbox()
    {
        if (inputs.DodgeInput && !activateHitbox) activateHitbox = true;
    }

    private void Dodge()
    {
        if (dodgeTimer > 0)
        {
            dodgeTimer -= Time.fixedDeltaTime;
            timeCount += Time.fixedDeltaTime;
            _pcStateMachine.pcController.pcReferences.rb.velocity = direction * dodgeSpeed;
            SetVulnerability();
            if (_pcStateMachine.pcController.receivedDamage > 0)
            {
                _pcStateMachine.pcController.DodgeInterruptedFeedbackSet();
                DodgeEnd();
            }
        }
        else DodgeEnd();
    }

    private void SetVulnerability()
    {
        PCData pcData = _pcStateMachine.pcController.pcReferences.pcData;
        if (timeCount >= pcData.dodgeInvulnerabilityStart && timeCount < pcData.dodgeInvulnerabilityEnd)
        {
            SetHitbox();
            _pcStateMachine.gameObject.tag = pcData.invulnerabilityTag;
            if (activateHitbox) ActivateElementalHitbox(pcData);
        }
        else if (timeCount >= pcData.dodgeInvulnerabilityEnd)
        {
            _pcStateMachine.gameObject.tag = playerTag;
            _pcStateMachine.pcController.dodgeHitbox.gameObject.SetActive(false);
        }
    }
    private void ActivateElementalHitbox(PCData pcData)
    {
        PCNectar pcNectar = _pcStateMachine.pcController.pcReferences.pcNectar;
        if (!_pcStateMachine.pcController.dodgeHitbox.gameObject.activeSelf && pcNectar.NectarSubtract(pcData.dodgeApplicationNectarCost)) _pcStateMachine.pcController.dodgeHitbox.gameObject.SetActive(true);
    }

    private void DodgeEnd()
    {
        _pcStateMachine.pcController.pcReferences.rb.velocity = Vector3.zero;
        _pcStateMachine.pcController.SetDodgeEndCooldown(_pcStateMachine.pcController.pcReferences.pcData.dodgeEndCooldown);
        _pcStateMachine.pcController.lockDodgeSpam = true;
        Transitions();
    }

    #region Transitions
    private void Transitions()
    {
        GoToIdleState(inputs);
        GoToMovementState(inputs);
        GoToAttackState(inputs);
        GoToSkillState(inputs);
    }
    #region ToIdleState
    private void GoToIdleState(Inputs inputs)
    {
        if (inputs.MovementInput == Vector3.zero)
        {
            _pcStateMachine.SetState(new PCIdle(_pcStateMachine));
            _pcStateMachine.pcController.pcReferences.rb.velocity = Vector3.zero;
        }
    }
    #endregion
    #region ToMovementState
    private void GoToMovementState(Inputs inputs)
    {
        if ((inputs.MovementInput != UnityEngine.Vector3.zero)) _pcStateMachine.SetState(new PCMoving(_pcStateMachine));
    }
    #endregion
    #region ToAttackState
    private void GoToAttackState(Inputs inputs)
    {
        if (inputs.LeftClickInput && !_pcStateMachine.pcController.pcReferences.pcCombo.comboDelay) _pcStateMachine.SetState(new PCAttack(_pcStateMachine));
    }
    #endregion
    #region ToSkillState
    private void GoToSkillState(Inputs inputs)
    {
        if (inputs.RightClickInput) _pcStateMachine.SetState(new PCSkill(_pcStateMachine));
    }
    #endregion
    #endregion
}
