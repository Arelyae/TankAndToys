using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicRotation", menuName = "RSF/Rotation/BasicRotation")]
public class BasicRotationFunction : RotationFunctionTemplate
{
    public override void Rotate(Transform t, Vector2 direction, float rotationSpeed)
    {
        // Check if there's meaningful input
        if (direction.magnitude > 0.1f)
        {
            // Calculate the target angle for rotation (in degrees)
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Smoothly rotate towards the target angle
            float currentAngle = Mathf.LerpAngle(t.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
            t.rotation = Quaternion.Euler(0, 0, currentAngle);
        }
    }
}