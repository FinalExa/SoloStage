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

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        inputs = this.gameObject.GetComponent<Inputs>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        pcCombo = this.gameObject.GetComponent<PCCombo>();
    }
}
