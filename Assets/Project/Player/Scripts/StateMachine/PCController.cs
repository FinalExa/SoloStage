using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCController : MonoBehaviour
{
    [HideInInspector] public string curState;
    [HideInInspector] public PCReferences pcReferences;
    [HideInInspector] public float actualSpeed;
    [SerializeField] private string whoToDamage;
    public GameObject rotator;
    public Weapon equippedWeapon;
    private void Start()
    {
        pcReferences.health.SetHPStartup(pcReferences.pcData.maxHP);
        equippedWeapon.damageTag = whoToDamage;
    }

    private void Awake()
    {
        pcReferences = this.gameObject.GetComponent<PCReferences>();
    }
}
