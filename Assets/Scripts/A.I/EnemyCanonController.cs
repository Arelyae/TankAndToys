using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanonController : MonoBehaviour
{
    Vector2 playerDirection;
    [SerializeField] PlayerData playerData;
    [SerializeField] CanonFunctionTemplate canonFunction;

    private void Update()
    {
        canonFunction.FaceTargetPositon(playerData.playerTransform, transform);
    }


    void HandleInput()
    {
        playerDirection = playerData.playerTransform.position - transform.position;
    }
}
