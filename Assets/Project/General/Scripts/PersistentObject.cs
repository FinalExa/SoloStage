using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    private void Awake()
    {
        PersistentObject[] persistentObjects = FindObjectsOfType<PersistentObject>();
        if (persistentObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
