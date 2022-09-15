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
    public Rotation rotation;
    public GameObject rotator;
    public Weapon equippedWeapon;
    public Element equippedElement;
    private int elementIndex;
    [SerializeField] private Element[] availableElements;
    private void Start()
    {
        pcReferences.health.SetHPStartup(pcReferences.pcData.maxHP);
        equippedWeapon.damageTag = whoToDamage;
        elementIndex = 0;
        SetElement();
    }

    private void Update()
    {
        Infusion();
        SwitchElement();
    }
    private void SetElement()
    {
        equippedElement.element = availableElements[elementIndex].element;
        print(equippedElement.element);
    }
    private void SwitchElement()
    {
        if (pcReferences.inputs.DodgeInput)
        {
            elementIndex++;
            if (elementIndex >= availableElements.Length) elementIndex = 0;
            SetElement();
        }
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
