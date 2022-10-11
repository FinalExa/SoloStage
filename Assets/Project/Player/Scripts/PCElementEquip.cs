using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCElementEquip : MonoBehaviour
{
    [SerializeField] private Reaction.Element[] availableElements;
    private int elementIndex;
    private PCReferences pcReferences;
    [HideInInspector] public Reaction.Element equippedElement;
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
        equippedElement = availableElements[elementIndex];
    }
    private void SwitchElement()
    {
        if (pcReferences.inputs.ElementSwitchInput)
        {
            elementIndex++;
            if (elementIndex >= availableElements.Length) elementIndex = 0;
            SetElement();
        }
    }
}
