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
    private Health playerHealthRef;
    private PCNectar playerNectarRef;
    private PCElementEquip playerElementEquip;
    private bool canUpdate;
    private void Awake()
    {
        playerHealthRef = this.gameObject.GetComponentInParent<Health>();
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
        if (playerHealthRef != null && playerElementEquip != null)
        {
            canUpdate = true;
            playerHealth.minValue = 0;
            playerHealth.maxValue = playerHealthRef.maxHP;
            playerHealth.value = playerHealth.maxValue;
            playerNectar.minValue = 0;
            playerNectar.maxValue = playerNectarRef.maxNectar;
            playerNectar.value = playerNectar.maxValue;
        }
    }
    private void PlayerUIUpdate()
    {
        if (canUpdate)
        {
            equippedElementText.text = playerElementEquip.equippedElement.element.ToString();
            playerHealth.value = playerHealthRef.currentHP;
            playerNectar.value = playerNectarRef.currentNectar;
        }
    }
}
