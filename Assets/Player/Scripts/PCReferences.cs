using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCReferences : MonoBehaviour
{
    public PCData pcData;
    [HideInInspector] public Inputs pcInputs;
    [HideInInspector] public Rigidbody pcRb;
    [HideInInspector] public Combo pcCombo;
    [HideInInspector] public Infusion infusion;
    [HideInInspector] public StaminaGauge staminaGauge;
    [HideInInspector] public Camera mainCameraRef;
    public UXEffect uxOnDodge;

    private void Awake()
    {
        pcInputs = this.gameObject.GetComponent<Inputs>();
        pcRb = this.gameObject.GetComponent<Rigidbody>();
        pcCombo = this.gameObject.GetComponent<Combo>();
        infusion = this.gameObject.GetComponent<Infusion>();
        staminaGauge = this.gameObject.GetComponent<StaminaGauge>();
        mainCameraRef = FindObjectOfType<Camera>();
    }
}
