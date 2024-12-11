using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


[CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/New Bullet Data", order = 1)]

public class BulletRso : ScriptableObject
{
    public string bulletName;
    public float speed;

    public float life;

}
