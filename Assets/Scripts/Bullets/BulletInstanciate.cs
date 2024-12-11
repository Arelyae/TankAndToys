using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInstanciate : MonoBehaviour
{

    public TankDataRSo TankDataRso;
    public Transform spawnPoint;

    public void FireBullet()
    {
        Instantiate(TankDataRso.bulletUsed, spawnPoint.position, spawnPoint.rotation);

        if (spawnPoint == null || TankDataRso.bulletUsed == null)
        {
            Debug.LogWarning("SpawnPoint or ObjectToSpawn is not assigned.");
            return;
        }
    }
}
