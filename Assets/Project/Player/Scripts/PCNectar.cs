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
    private bool nectarSubtracted;
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
    public bool NectarSubtract(float amount)
    {
        if (currentNectar - amount >= 0)
        {
            currentNectar -= amount;
            nectarSubtracted = true;
            return true;
        }
        else return false;
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
        else if (currentNectar < maxNectar && !isInfused && !nectarRegen) SetupNectarRegenCooldown();
    }
    private void NectarRegen()
    {
        if (nectarRegen && currentNectar < maxNectar && !nectarSubtracted)
        {
            currentNectar = Mathf.Clamp(currentNectar + (pcReferences.pcData.nectarRegenPerSecond * Time.deltaTime), 0f, pcReferences.pcData.maxNectar);
        }
        else if (currentNectar == maxNectar || nectarSubtracted) nectarRegen = false;
    }
    private void SetupNectarRegenCooldown()
    {
        nectarRegen = false;
        nectarSubtracted = false;
        nectarRegenCooldown = true;
        nectarCooldownTimer = pcReferences.pcData.nectarStopRegenCooldown;
    }
}
