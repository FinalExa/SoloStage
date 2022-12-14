using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PCCombo : MonoBehaviour
{
    private PCReferences pcReferences;
    [SerializeField] private PlayableDirector[] comboHits;
    [HideInInspector] public bool comboHitOver;
    [HideInInspector] public int currentComboProgress;
    [HideInInspector] public float comboDelayTimer;
    [HideInInspector] public float comboCancelTimer;
    [HideInInspector] public bool delayAfterHit;
    private bool comboCancelDelay;

    private void Awake()
    {
        pcReferences = this.gameObject.GetComponent<PCReferences>();
    }

    private void Start()
    {
        ComboSetup();
    }

    private void FixedUpdate()
    {
        if (delayAfterHit) DelayAfterHit();
        if (comboCancelDelay) CountToCancelCombo();
    }

    private void ComboSetup()
    {
        comboHitOver = false;
        delayAfterHit = false;
        currentComboProgress = 0;
        comboHits[currentComboProgress].gameObject.SetActive(false);

    }
    public void StartComboHitCheck()
    {
        if (!delayAfterHit) StartComboHit();
    }

    private void DelayAfterHit()
    {
        if (comboDelayTimer > 0) comboDelayTimer -= Time.fixedDeltaTime;
        else delayAfterHit = false;
    }

    private void StartComboHit()
    {
        comboHitOver = false;
        if (comboCancelDelay) comboCancelDelay = false;
        comboHits[currentComboProgress].Play();
    }

    private void CountToCancelCombo()
    {
        if (comboCancelTimer > 0) comboCancelTimer -= Time.fixedDeltaTime;
        else
        {
            comboHits[currentComboProgress].gameObject.SetActive(false);
            currentComboProgress = 0;
            comboHits[currentComboProgress].gameObject.SetActive(true);
            comboCancelDelay = false;
        }
    }

    public void EndComboHit()
    {
        comboHits[currentComboProgress].gameObject.SetActive(false);
        if (currentComboProgress + 1 == comboHits.Length)
        {
            currentComboProgress = 0;
            comboDelayTimer = pcReferences.pcData.comboEndCooldown;
        }
        else
        {
            currentComboProgress++;
            comboDelayTimer = pcReferences.pcData.comboDelayBetweenHits;
            comboCancelTimer = pcReferences.pcData.comboResetCooldown;
            comboCancelDelay = true;
        }
        delayAfterHit = true;
        comboHits[currentComboProgress].gameObject.SetActive(true);
        comboHitOver = true;
    }
}
