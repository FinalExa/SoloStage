using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    [SerializeField] private int fps;
    private void Start()
    {
        Application.targetFrameRate = fps;
        QualitySettings.vSyncCount = 1;
    }
}
