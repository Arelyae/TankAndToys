using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankData", menuName = "ScriptableObjects/New Tank Data", order = 1)]
public class TankDataRSo : ScriptableObject
{
    public string nameOfTank;

    [Header("Is player")]
    public bool player;

    [Header("Movement")]
    public float speed;
    public float rotationSpeed;

    [Header("Weapons")]
    public GameObject bulletUsed;
    public GameObject mineUsed;


    [Header("Apparence")]
    public Color primarColor;
    public Color secondColor;
}
