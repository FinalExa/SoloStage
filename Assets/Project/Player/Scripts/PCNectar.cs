using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCNectar : MonoBehaviour
{
    [HideInInspector] public float maxNectar;
    [HideInInspector] public float currentNectar;
    [HideInInspector] public bool isInfused;
    private bool nectarRegenCooldown;
    private bool nectarRegen;
    private float nectarCooldownTimer;
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
    private void Update()
    {
        Infusion();
        DrainNectar();
        NectarRegen();
        NectarRegenCooldown();
    }
    private void Infusion()
    {
        if (pcReferences.inputs.InfuseInput)
        {
            isInfused = !isInfused;
            if (isInfused && (nectarRegen || nectarRegenCooldown))
            {
                nectarRegen = false;
                nectarRegenCooldown = false;
            }
            if (!isInfused && currentNectar < maxNectar) SetupNectarRegenCooldown();
        }
    }
    private void DrainNectar()
    {
        if (isInfused && currentNectar > 0f)
        {
            float drainValue = pcReferences.pcData.nectarDrainPerSecond * Time.deltaTime;
            currentNectar = Mathf.Clamp(currentNectar - drainValue, 0f, maxNectar);
            if (currentNectar <= 0f)
            {
                isInfused = false;
                SetupNectarRegenCooldown();
            }
        }
    }
    private void NectarRegenCooldown()
    {
        if (nectarRegenCooldown)
        {
            if (nectarCooldownTimer > 0) nectarCooldownTimer -= Time.deltaTime;
            else
            {
                nectarRegenCooldown = false;
                nectarRegen = true;
            }
        }
    }
    private void NectarRegen()
    {
        if (nectarRegen && currentNectar < maxNectar)
        {
            currentNectar = Mathf.Clamp(currentNectar + (pcReferences.pcData.nectarRegenPerSecond * Time.deltaTime), 0f, pcReferences.pcData.maxNectar);
        }
        else if (currentNectar == maxNectar) nectarRegen = false;
    }
    private void SetupNectarRegenCooldown()
    {
        nectarRegen = false;
        nectarRegenCooldown = true;
        nectarCooldownTimer = pcReferences.pcData.nectarStopRegenCooldown;
    }
}
