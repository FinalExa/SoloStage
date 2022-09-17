using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReactionText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Vector3 localPositionStart;
    [SerializeField] private Vector3 movementDirection;
    [SerializeField] private float movementDistance;
    [SerializeField] private float movementTime;
    private float movementTimer;
    private bool isSet;

    private void Update()
    {
        ReactionTextLifeTime();
    }
    private void ReactionTextLifeTime()
    {
        if (isSet)
        {
            if (movementTimer > 0)
            {
                movementTimer -= Time.deltaTime;
                this.gameObject.transform.position += movementDirection * (movementDistance * Time.deltaTime);
            }
            else GameObject.Destroy(this.gameObject);
        }
    }
    public void SetReactionText(string textToSet)
    {
        this.transform.position += localPositionStart;
        text.text = textToSet;
        movementTimer = movementTime;
        isSet = true;
    }
}
