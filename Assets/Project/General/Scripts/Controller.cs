using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float actualHealth;

    public virtual void HealthAddValue(float value)
    {
        actualHealth += value;
        if (actualHealth <= 0) this.gameObject.SetActive(false);
    }
}
