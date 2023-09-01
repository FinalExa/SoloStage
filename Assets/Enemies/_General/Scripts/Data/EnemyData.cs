using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/Enemies/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    [Header("General")]
    public string enemyName;
    public float maxHP;
    public float movementSpeed;
    public float normalDistanceFromPlayer;
    public float normalDistanceTolerance;
    public Weapon weapon;
}
