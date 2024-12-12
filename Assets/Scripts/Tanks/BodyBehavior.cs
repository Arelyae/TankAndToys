using UnityEngine;

public class BodyBehavior : MonoBehaviour
{
    public TankDataRSo TankDataRSo;

    public GameObject objectToDestroy;

    private float moveSpeed;
    private float rotationSpeed;
    public float angleTolerance;

    private Vector2 inputDirection; 

    private void Start()
    {
        moveSpeed = TankDataRSo.speed;
        rotationSpeed = TankDataRSo.rotationSpeed;
    }

    private void FixedUpdate()
    {
        HandlePlayerInput();
        HandleRotation(inputDirection);
        HandleMovement(inputDirection);
    }

    /// <summary>
    /// Handles input from the player and updates the input direction.
    /// </summary>
    private void HandlePlayerInput()
    {
        // Get horizontal and vertical input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement direction vector for 2D (X, Y)
        inputDirection = new Vector2(moveHorizontal, moveVertical).normalized;
    }

    /// <summary>
    /// Handles the rotation of the body based on the provided direction.
    /// </summary>
    /// <param name="direction">The direction vector to rotate towards.</param>
    private void HandleRotation(Vector2 direction)
    {
        // Check if there's meaningful input
        if (direction.magnitude > 0.1f)
        {
            // Calculate the target angle for rotation (in degrees)
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Smoothly rotate towards the target angle
            float currentAngle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, currentAngle);
        }
    }

    /// <summary>
    /// Handles the movement of the body if it is within the allowed rotation tolerance.
    /// </summary>
    /// <param name="direction">The direction vector to move in.</param>
    private void HandleMovement(Vector2 direction)
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage") 
        { 
            Destroy(objectToDestroy);
        }
    }

}