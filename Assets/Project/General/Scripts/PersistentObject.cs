using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    [SerializeField] private int fps;
    private void Awake()
    {
        PersistentObject[] persistentObjects = FindObjectsOfType<PersistentObject>();
        if (persistentObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        Application.targetFrameRate = fps;
        QualitySettings.vSyncCount = 1;
    }
}
