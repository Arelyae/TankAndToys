using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicMovement", menuName = "RSF/Movement/BasicMovement")]

public class BasicMovementFunction : MovementFunctionTemplate
{
    public override void HandleMovement(Transform transform, Vector2 direction, float moveSpeed, float angleTolerance)
    {
        // Check if there's meaningful input
        if (direction.magnitude > 0.1f)
        {
            // Calculate the target angle for rotation (in degrees)
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Calculate the difference between the current angle and target angle
            float angleDifference = Mathf.DeltaAngle(transform.eulerAngles.z, targetAngle);

            // Allow movement only if the player is oriented within the angle tolerance
            if (Mathf.Abs(angleDifference) <= angleTolerance)
            {
                // Move forward in the direction the object is facing
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.Self);
            }
        }
    }
}
