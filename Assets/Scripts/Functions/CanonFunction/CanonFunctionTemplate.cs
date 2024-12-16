using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CanonFunctionTemplate : ScriptableObject
{
    public abstract void FaceTargetPositon(Vector3 targetPosition, Transform t);
}
