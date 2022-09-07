using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        this.gameObject.transform.position = objectToFollow.transform.position + offset;
    }
}
