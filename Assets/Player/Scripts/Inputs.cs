using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public bool LeftClickInput { get; private set; }
    public bool RightClickInput { get; private set; }
    public Vector3 MovementInput { get; private set; }
    public bool DodgeInput { get; private set; }
    public bool ElementSwitchInput { get; private set; }
    public bool InfuseInput { get; private set; }
    private void Update()
    {
        GetInputs();
    }
    void GetInputs()
    {
        GetLeftClickInput();
        GetRightClickInput();
        GetMovementInput();
        GetDodgeInput();
        GetElementSwitchInput();
        GetInfuseInput();
    }
    void GetLeftClickInput()
    {
        if (Input.GetButton("Fire1") == true) LeftClickInput = true;
        else LeftClickInput = false;
    }
    void GetRightClickInput()
    {
        if (Input.GetButton("Fire2") == true) RightClickInput = true;
        else RightClickInput = false;
    }
    void GetMovementInput()
    {
        float frontInput = Input.GetAxisRaw("Horizontal");
        float sideInput = Input.GetAxisRaw("Vertical");
        MovementInput = new Vector3(sideInput, 0, frontInput).normalized;
    }
    void GetDodgeInput()
    {
        if (Input.GetKey(KeyCode.LeftShift) == true) DodgeInput = true;
        else DodgeInput = false;
    }
    void GetElementSwitchInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true) ElementSwitchInput = true;
        else ElementSwitchInput = false;
    }
    void GetInfuseInput()
    {
        if (Input.GetKeyDown(KeyCode.E) == true) InfuseInput = true;
        else InfuseInput = false;
    }
    public void StopAllInputs()
    {
        LeftClickInput = false;
        RightClickInput = false;
        InfuseInput = false;
        MovementInput = Vector3.zero.normalized;
    }
}