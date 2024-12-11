using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankData", menuName = "ScriptableObjects/New Tank Data", order = 1)]
public class TankDataRSo : ScriptableObject
{
    public string nameOfTank;

    public bool player;

    public float speed;
    public float rotationSpeed;



    public GameObject bulletUsed;
}
