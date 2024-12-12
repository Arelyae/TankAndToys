using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInstanciate : MonoBehaviour
{

    public TankDataRSo TankDataRso;
    public BulletRso bulletDataRso;
    public Transform spawnPoint;

    private float currentMag;
    private float reloadTime;
    private float cooldown;
    private bool shouldReload;
    private bool isLoaded;
    private bool canShoot;

    private void Start()
    {
        currentMag = bulletDataRso.magSize;
        reloadTime = bulletDataRso.reloadTime;
    }

    private void Update()
    {
        Reloading();
        FiringAgain();
    }

    public void Reloading()
    {
        if (shouldReload) 
        {
            reloadTime -= Time.deltaTime;

            if (reloadTime <= 0 && currentMag < bulletDataRso.magSize) 
            {
                currentMag += 1;
                if(currentMag >= bulletDataRso.magSize)
                {
                    shouldReload = false;

                }
                reloadTime = bulletDataRso.reloadTime;
            }

        }
    }

    public void FiringAgain()
    {
        if (!canShoot) 
        { 
            cooldown -= Time.deltaTime;
            if(cooldown <= 0)
            {
                canShoot = true;
            }
        }

    }

    public void FireBullet()
    {

        if (currentMag > 0 && canShoot)
        {
            Instantiate(TankDataRso.bulletUsed, spawnPoint.position, spawnPoint.rotation);
            currentMag--;
            shouldReload = true;
            canShoot = false;
            cooldown = bulletDataRso.fireRate;
        }

        if (spawnPoint == null || TankDataRso.bulletUsed == null)
        {
            Debug.LogWarning("SpawnPoint or ObjectToSpawn is not assigned.");
            return;
        }
    }
}
