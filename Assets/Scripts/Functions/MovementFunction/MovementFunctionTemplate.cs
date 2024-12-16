using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MovementFunctionTemplate : ScriptableObject
{
    public abstract void HandleMovement(Transform transform, Vector2 direction, float moveSpeed, float angleTolerance);
}
