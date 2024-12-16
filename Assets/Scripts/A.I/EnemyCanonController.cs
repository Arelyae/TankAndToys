using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanonController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] CanonFunctionTemplate canonFunction;

    private void Update()
    {
        canonFunction.FaceTargetPositon(playerData.playerTransform, transform);
    }
}
