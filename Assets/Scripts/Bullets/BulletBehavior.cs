using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public BulletRso bulletRso; // Scriptable Object to store bullet settings

    private float moveSpeed; // Speed of the bullet
    private Vector2 currentDirection; // Direction the bullet is moving
    public float life; // Number of bounces before the bullet is destroyed
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        moveSpeed = bulletRso.speed; // Get speed from the ScriptableObject
        life = bulletRso.life; // Get life from the ScriptableObject
        currentDirection = transform.up.normalized; // Start moving in the direction the object is facing
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = bulletRso.primarColor;

    }

    void Update()
    {
        // Move the bullet in its current direction
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        life--;

        // Destroy the bullet if life is 0
        if (life <= 0)
        {
            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.tag != "Tank")
        {
            // Get the normal of the surface hit
            Vector2 normal = collision.contacts[0].normal;

            // Reflect the current direction based on the wall's normal
            Vector2 reflectedDirection = Vector2.Reflect(currentDirection, normal);

            // Adjust the reflection angle based on the speed
            float speedFactor = Mathf.Clamp(moveSpeed / 10f, 0.5f, 2f); // Example: Scale factor based on speed
            float adjustmentAngle = speedFactor * 15f; // Decrease steepness with higher speed

            // Calculate the new direction with an additional angle adjustment
            float angle = Mathf.Atan2(reflectedDirection.y, reflectedDirection.x) * Mathf.Rad2Deg;
            angle += currentDirection.y > 0 ? adjustmentAngle : -adjustmentAngle;

            // Update the direction vector
            currentDirection = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;

            // Update the rotation of the bullet to face the new direction
            transform.up = currentDirection;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
