using UnityEngine;

public class BodyBehavior : MonoBehaviour
{
    public TankDataRSo TankDataRSo;

     float moveSpeed;
     float rotationSpeed; 
     public float angleTolerance;

    private void Start()
    {
        moveSpeed = TankDataRSo.speed;
        rotationSpeed = TankDataRSo.rotationSpeed;
    }
    void FixedUpdate()
    {
        BodyRotationAndMovement();
    }

    public void BodyRotationAndMovement()
    {
        // Get horizontal and vertical input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement direction vector for 2D (X, Y)
        Vector2 moveDirection = new Vector2(moveHorizontal, moveVertical).normalized;

        // Check if there's meaningful input
        if (moveDirection.magnitude > 0.1f)
        {
            // Calculate the target angle for rotation (in degrees)
            float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

            // Smoothly rotate towards the target angle
            float currentAngle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, currentAngle);

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
