using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PCReferences : MonoBehaviour
{
    public PCData pcData;
    [HideInInspector] public Camera cam;
    [HideInInspector] public Inputs inputs;
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public PCCombo pcCombo;
    [HideInInspector] public PlayableDirector combos;
    [HideInInspector] public Health health;
    [HideInInspector] public PCElementEquip pcElementEquip;
    [HideInInspector] public PCNectar pcNectar;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        inputs = this.gameObject.GetComponent<Inputs>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        pcCombo = this.gameObject.GetComponent<PCCombo>();
        health = this.gameObject.GetComponent<Health>();
        pcElementEquip = this.gameObject.GetComponent<PCElementEquip>();
        pcNectar = this.gameObject.GetComponent<PCNectar>();
    }
}
