using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


[CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/New Bullet Data", order = 1)]

public class BulletRso : ScriptableObject
{
    public string bulletName;

    [Header("Bullet Behavior")]
    public float speed;
    public float life;

    [Header("Bullet Rate")]
    public float magSize;
    public float reloadTime;
    public float fireRate;

    [Header("Apparence")]
    public Color primarColor;


}
