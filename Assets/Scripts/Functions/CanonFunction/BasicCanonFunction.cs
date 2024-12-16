using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicCanon", menuName = "RSF/Rotation/BasicCanon")]
public class BasicCanonFunction : CanonFunctionTemplate
{
    public override void FaceTargetPositon(Vector3 targetPosition, Transform t)
    {
        // Calculate the direction from the object to the mouse position
        Vector3 direction = targetPosition - t.position;

        // Rotate to face the mouse position
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Calculate angle to the mouse
        t.rotation = Quaternion.Euler(0, 0, angle); // Apply rotation in 2D space

    }
}
