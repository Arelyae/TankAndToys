using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CreateAssetMenu(fileName = "BasicCanon", menuName = "RSF/Rotation/BasicCanon")]
public class BasicCanonFunction : CanonFunctionTemplate
{
    public override void FaceTargetPositon(Transform targetPosition, Transform t)
    {
        // Calculate the direction to the target
        Vector2 direction = (targetPosition.position - t.position).normalized;

        // Get the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the transform to face the target
        t.rotation = Quaternion.Euler(0, 0, angle);

    }
}
