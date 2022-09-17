using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Slider enemyHealth;
    [SerializeField] private TMP_Text appliedElement;
    private Health enemyHealthRef;
    private ReactionAgent enemyReactionAgentRef;
    private bool canUpdate;

    private void Awake()
    {
        enemyHealthRef = this.gameObject.GetComponentInParent<Health>();
        enemyReactionAgentRef = this.gameObject.GetComponentInParent<ReactionAgent>();
    }

    private void Start()
    {
        EnemyUIStartup();
    }
    private void Update()
    {
        EnemyUIUpdate();
    }
    private void EnemyUIStartup()
    {
        if (enemyHealthRef != null)
        {
            canUpdate = true;
            SetHealthBarStartup();
        }
    }

    private void SetHealthBarStartup()
    {
        enemyHealth.minValue = 0f;
        enemyHealth.maxValue = enemyHealthRef.maxHP;
        enemyHealth.value = enemyHealth.maxValue;
        appliedElement.gameObject.SetActive(false);
    }
    private void EnemyUIUpdate()
    {
        if (canUpdate)
        {
            if (enemyHealthRef.currentHP != enemyHealth.value) enemyHealth.value = enemyHealthRef.currentHP;
            if (enemyReactionAgentRef.appliedElement.element != Element.Elements.NONE)
            {
                if (!appliedElement.gameObject.activeSelf) appliedElement.gameObject.SetActive(true);
                if (appliedElement.text != enemyReactionAgentRef.appliedElement.element.ToString()) appliedElement.text = enemyReactionAgentRef.appliedElement.element.ToString();
            }
            else if (appliedElement.gameObject.activeSelf) appliedElement.gameObject.SetActive(false);
        }
    }
}
