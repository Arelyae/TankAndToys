using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExplosionData", menuName = "ScriptableObjects/New Explosion Data", order = 1)]

public class ExplosionRso : ScriptableObject
{
    [Header("Behavior")]
    public float originalSize;
    public float targetSize;
    public float time;

    [Header("Appareance")]
    public Color firstColor;
    public Color secondColor;
    public Color dissappearanceColor;

}
