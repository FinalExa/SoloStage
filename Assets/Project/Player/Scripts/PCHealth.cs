using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PCHealth : Health
{
    private PCController pcController;
    private void Awake()
    {
        pcController = this.gameObject.GetComponent<PCController>();
    }
    public override void HealthAddValue(float healthToAdd)
    {
        currentHP += healthToAdd;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        //THIS IS SUPER TEMP
        pcController.receivedDamage = 5;
        if (currentHP <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
