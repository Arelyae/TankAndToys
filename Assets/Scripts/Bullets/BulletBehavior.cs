using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public BulletRso bulletRso; 
    public float angleOffset = 45f; 

    private float moveSpeed; 
    private Vector2 currentDirection; 
    public float life;


    private void Start()
    {
        moveSpeed = bulletRso.speed;
        currentDirection = Vector2.up; 
        life = bulletRso.life;
    }

    void Update()
    {
        transform.Translate(currentDirection * -moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        life--;

        if(life <= 0 )
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag != "Tank")
        {
            currentDirection = -currentDirection;

            float Offset = 45;
            ApplyAngleOffset(Offset);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void ApplyAngleOffset(float angleOffset)
    {
        float currentAngle = Mathf.Atan2(currentDirection.y, currentDirection.x) * Mathf.Rad2Deg;

        if (currentAngle > 0 && currentAngle <= 180)
        {
            currentAngle += angleOffset; 
        }
        else
        {
            currentAngle -= angleOffset; 
        }

        currentDirection = new Vector2(Mathf.Cos(currentAngle * Mathf.Deg2Rad), Mathf.Sin(currentAngle * Mathf.Deg2Rad));
    }
}
