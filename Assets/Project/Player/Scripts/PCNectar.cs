using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCNectar : MonoBehaviour
{
    [HideInInspector] public float maxNectar;
    [HideInInspector] public float currentNectar;
    private PCReferences pcReferences;

    private void Awake()
    {
        pcReferences = this.gameObject.GetComponent<PCReferences>();
    }

    private void Start()
    {
        maxNectar = pcReferences.pcData.maxNectar;
        currentNectar = maxNectar;
    }
}
