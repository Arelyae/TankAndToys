using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RotationFunctionTemplate : ScriptableObject
{
    public abstract void Rotate(Transform t, Vector2 direction, float rotationSpeed);
}