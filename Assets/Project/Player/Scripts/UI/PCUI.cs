using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PCUI : MonoBehaviour
{
    [SerializeField] private Slider playerHealth;
    [SerializeField] private Slider playerNectar;
    [SerializeField] private TMP_Text equippedElementText;
    [SerializeField] private TMP_Text infusedText;
    private PCHealth playerHealthRef;
    private PCNectar playerNectarRef;
    private PCElementEquip playerElementEquip;
    private bool canUpdate;
    private void Awake()
    {
        playerHealthRef = this.gameObject.GetComponentInParent<PCHealth>();
        playerNectarRef = this.gameObject.GetComponentInParent<PCNectar>();
        playerElementEquip = this.gameObject.GetComponentInParent<PCElementEquip>();
    }

    private void Start()
    {
        PlayerUISetup();
    }

    private void Update()
    {
        PlayerUIUpdate();
    }

    private void PlayerUISetup()
    {
        if (playerHealthRef != null && playerElementEquip != null && playerNectar != null)
        {
            canUpdate = true;
            equippedElementText.text = string.Empty;
            SetHealthBarStartup();
            SetNectarBarStartup();
        }
    }
    private void SetHealthBarStartup()
    {
        playerHealth.minValue = 0;
        playerHealth.maxValue = playerHealthRef.maxHP;
        playerHealth.value = playerHealth.maxValue;
    }
    private void SetNectarBarStartup()
    {
        playerNectar.minValue = 0;
        playerNectar.maxValue = playerNectarRef.maxNectar;
        playerNectar.value = playerNectar.maxValue;
    }
    private void PlayerUIUpdate()
    {
        if (canUpdate)
        {
            equippedElementText.text = playerElementEquip.equippedElement.element.ToString();
            infusedText.gameObject.SetActive(playerNectarRef.isInfused);
            if (playerHealthRef.currentHP != playerHealth.value) playerHealth.value = playerHealthRef.currentHP;
            if (playerNectarRef.currentNectar != playerNectar.value) playerNectar.value = playerNectarRef.currentNectar;
        }
    }
}
