using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCElementEquip : MonoBehaviour
{
    [SerializeField] private Element[] availableElements;
    private int elementIndex;
    private PCController pcController;
    private PCReferences pcReferences;
    [HideInInspector] public bool isInfused;
    [HideInInspector] public Element equippedElement;
    private void Awake()
    {
        pcController = this.gameObject.GetComponent<PCController>();
        pcReferences = this.gameObject.GetComponent<PCReferences>();
    }

    private void Start()
    {
        ElementsStartup();
    }

    private void Update()
    {
        Infusion();
        SwitchElement();
    }
    private void ElementsStartup()
    {
        elementIndex = 0;
        SetElement();
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
}
