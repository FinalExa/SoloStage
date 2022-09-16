using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCElementEquip : MonoBehaviour
{
    [SerializeField] private Element[] availableElements;
    private int elementIndex;
    private PCReferences pcReferences;
    [HideInInspector] public Element equippedElement;
    private void Awake()
    {
        pcReferences = this.gameObject.GetComponent<PCReferences>();
    }

    private void Start()
    {
        ElementsStartup();
    }

    private void Update()
    {
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
}
