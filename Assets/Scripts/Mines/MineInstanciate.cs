using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineInstanciate : MonoBehaviour
{

    public TankDataRSo TankDataRso;
    public MineRso mineDataRso;
    public Transform spawnPoint;

    private bool canSpawn;
    private float spawnRate;

    private void Start()
    {
        spawnRate = mineDataRso.spawnRate;
    }

    public void MineInstanciating()
    {
        if (canSpawn) 
        {
            Instantiate(TankDataRso.mineUsed, spawnPoint.position, spawnPoint.rotation);
            canSpawn = false;
        }
        
    }

    private void Update()
    {
        Reload();
    }


    private void Reload()
    {
        if (!canSpawn) 
        { 
            spawnRate -= Time.deltaTime;
            if(spawnRate < 0 )
            {
                canSpawn = true;
                spawnRate = mineDataRso.spawnRate;
            }
        }
    }

}
