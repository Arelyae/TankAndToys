using UnityEngine;

public class BodyBehavior : MonoBehaviour
{
    public TankDataRSo TankDataRSo;
    public PlayerData PlayerData;


    private Vector2 inputDirection;

    public float targetAngle;

    [SerializeField] RotationFunctionTemplate rotationFunction;
    [SerializeField] MovementFunctionTemplate movementFunction;

    private void Start()
    {
        PlayerData.playerTransform = transform;
    }

    private void FixedUpdate()
    {
        HandlePlayerInput();
        rotationFunction.Rotate(transform, inputDirection, TankDataRSo.rotationSpeed);
        movementFunction.HandleMovement(transform, inputDirection, TankDataRSo.speed, TankDataRSo.angleTolerance);
    }

    /// <summary>
    /// Handles input from the player and updates the input direction.
    /// </summary>
    private void HandlePlayerInput()
    {
        // Get horizontal and vertical input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if(TankDataRSo.player)
        {
            inputDirection = new Vector2(moveHorizontal, moveVertical).normalized;
        }
    }
      

   
}
