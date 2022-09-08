using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCController : MonoBehaviour
{
    [HideInInspector] public string curState;
    [HideInInspector] public PCReferences pcReferences;
    [HideInInspector] public float actualSpeed;
    [HideInInspector] public bool isInfused;
    [SerializeField] private string whoToDamage;
    public GameObject rotator;
    public Weapon equippedWeapon;
    public Element equippedElement;
    private void Start()
    {
        pcReferences.health.SetHPStartup(pcReferences.pcData.maxHP);
        equippedWeapon.damageTag = whoToDamage;
    }

    private void Update()
    {
        Infusion();
    }

    private void Infusion()
    {
        if (pcReferences.inputs.InfuseInput)
        {
            isInfused = !isInfused;
            print(isInfused);
        }
    }

    private void Awake()
    {
        pcReferences = this.gameObject.GetComponent<PCReferences>();
    }
}
