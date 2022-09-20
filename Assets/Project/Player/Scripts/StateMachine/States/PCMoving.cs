using UnityEngine;
public class PCMoving : PCState
{
    private Vector3 lastDirection;
    private Rotation rotation;
    public PCMoving(PCStateMachine pcStateMachine) : base(pcStateMachine)
    {
        SetRotation();
    }
    public override void FixedUpdate()
    {
        Movement();
    }
    public override void Update()
    {
        Transitions();
        UpdateSpeedValue();
    }

    private void SetRotation()
    {
        rotation = _pcStateMachine.pcController.rotation;
    }

    #region Movement
    private void UpdateSpeedValue()
    {
        PCData pcData = _pcStateMachine.pcController.pcReferences.pcData;
        PCController pcController = _pcStateMachine.pcController;
        pcController.actualSpeed = pcData.defaultMovementSpeed;
    }
    private void Movement()
    {
        Rigidbody rigidbody = _pcStateMachine.pcController.pcReferences.rb;
        PCController pcController = _pcStateMachine.pcController;
        Vector3 movementWithDirection = MovementCalculateDirection();
        if (movementWithDirection != Vector3.zero) lastDirection = movementWithDirection;
        GetDirectionForRotation(movementWithDirection);
        rigidbody.velocity = movementWithDirection * pcController.actualSpeed;
    }

    private void GetDirectionForRotation(Vector3 direction)
    {
        Transform rotator = _pcStateMachine.pcController.rotator.transform;
        if (direction.x > 0 && rotator.eulerAngles != rotation.right) rotator.eulerAngles = rotation.right;
        else if (direction.x < 0 && rotator.eulerAngles != rotation.left) rotator.eulerAngles = rotation.left;
        if (direction.z > 0 && rotator.eulerAngles != rotation.forward) rotator.eulerAngles = rotation.forward;
        else if (direction.z < 0 && rotator.eulerAngles != rotation.back) rotator.eulerAngles = rotation.back;
    }

    private Vector3 MovementCalculateDirection()
    {
        Inputs inputs = _pcStateMachine.pcController.pcReferences.inputs;
        Vector3 movementDirection = new Vector3(inputs.MovementInput.z, 0f, inputs.MovementInput.x);
        movementDirection = movementDirection.normalized;
        return movementDirection;
    }
    #endregion

    #region Transitions
    private void Transitions()
    {
        Inputs inputs = _pcStateMachine.pcController.pcReferences.inputs;
        GoToIdleState(inputs);
        GoToAttackState(inputs);
        GoToDodgeState(inputs);
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
    #region ToAttackState
    private void GoToAttackState(Inputs inputs)
    {
        if (inputs.LeftClickInput && !_pcStateMachine.pcController.pcReferences.pcCombo.comboDelay)
        {
            _pcStateMachine.SetState(new PCAttack(_pcStateMachine));
            _pcStateMachine.pcController.pcReferences.rb.velocity = Vector3.zero;
        }
    }
    #endregion
    #region ToDodgeState
    private void GoToDodgeState(Inputs inputs)
    {
        if (inputs.DodgeInput)
        {
            _pcStateMachine.SetState(new PCDodge(_pcStateMachine, lastDirection));
        }
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
