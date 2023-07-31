using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infusion : MonoBehaviour, IReturnTheCurrentElement
{
    [HideInInspector] public bool infused;
    public ElementGauge.ElementTypes loadedElement;

    public ElementGauge.ElementTypes GetCurrentElement()
    {
        if (infused) return loadedElement;
        return ElementGauge.ElementTypes.NONE;
    }
}
