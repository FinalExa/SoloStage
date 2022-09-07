using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PCReferences : MonoBehaviour
{
    public PCData pcData;
    public Attack[] attack;
    [HideInInspector] public Camera cam;
    [HideInInspector] public Inputs inputs;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public PCCombo pcCombo;
    [HideInInspector] public PlayableDirector combos;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        inputs = this.gameObject.GetComponent<Inputs>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        pcCombo = this.gameObject.GetComponent<PCCombo>();
    }
}
