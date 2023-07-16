using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCController : MonoBehaviour
{
    [HideInInspector] public string curState;
    [HideInInspector] public Vector3 lookDirection;
    [HideInInspector] public PCReferences pcReferences;
    [HideInInspector] public PCMovement pcMovement;
    [SerializeField] private Weapon weaponSlot;

    private void Awake()
    {
        pcReferences = this.gameObject.GetComponent<PCReferences>();
        pcMovement = new PCMovement(this);
    }

    private void Start()
    {
        pcReferences.pcCombo.SetWeapon(weaponSlot);
    }
}
