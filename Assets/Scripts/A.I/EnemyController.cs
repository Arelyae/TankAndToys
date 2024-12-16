using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector2 playerDirection;
    [SerializeField] PlayerData playerData;
    [SerializeField] TankDataRSo tankDataRSo;

    [SerializeField] RotationFunctionTemplate rotationFunction;
    [SerializeField] MovementFunctionTemplate movementFunction;


    public void FixedUpdate()
    {
        HandleInput();
        rotationFunction.Rotate(transform, playerDirection, tankDataRSo.rotationSpeed);
        movementFunction.HandleMovement(transform, playerDirection, tankDataRSo.speed, tankDataRSo.angleTolerance);

    }

    void HandleInput()
    {
        playerDirection = playerData.playerTransform.position - transform.position;
    }



}
