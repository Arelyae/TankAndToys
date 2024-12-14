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

    [Header("Appearance")]
    public Color firstColor;
    public Color secondColor;
    public Color dissappearanceColor;

    [Header("Transition Curves")]
    public AnimationCurve sizeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1); // Default smooth curve
    public AnimationCurve colorCurve = AnimationCurve.EaseInOut(0, 0, 1, 1); // Default smooth curve
}
