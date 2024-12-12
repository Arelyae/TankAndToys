using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineInstanciate : MonoBehaviour
{

    public TankDataRSo TankDataRso;
    public Transform spawnPoint;

    public void MineInstanciating()
    {
        Instantiate(TankDataRso.mineUsed, spawnPoint.position, spawnPoint.rotation);
    }
}
