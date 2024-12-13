using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MineData", menuName = "ScriptableObjects/New Mine Data", order = 1)]

public class MineRso : ScriptableObject
{
    public string mineName;

    [Header("Bullet Behavior")]
    public float life;
    public float flickerDuration;

    [Header("Apparence")]
    public Color primarColor;
    public Color finalColor;

    [Header("Explosion")]
    public GameObject explosionType;

    [Header("Permissions")]
    public float spawnRate;

}
