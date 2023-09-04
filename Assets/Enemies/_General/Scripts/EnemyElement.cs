using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyElement : MonoBehaviour, IReturnTheCurrentElement
{
    [SerializeField] private ElementGauge.ElementTypes enemyElement;

    public ElementGauge.ElementTypes GetCurrentElement()
    {
        return enemyElement;
    }
}
