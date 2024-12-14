using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputPlayer : MonoBehaviour
{

    public UnityEvent OnLandMine;
    public UnityEvent OnFire;
    public TankDataRSo tankDataRSo;

    void Start()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLandMine();
        PlayerFireBullet();
    }

    public void PlayerLandMine()
    {

        if (Input.GetButton("Jump"))
        {
            Debug.Log("Player attempted to Land a mine");
            OnLandMine.Invoke();
        }
    }

    public void PlayerFireBullet()
    {
        if(Input.GetButton("Fire1") && tankDataRSo.player)
        {
            Debug.Log("Player attempted to fire");
            OnFire.Invoke();

        }
    }
}
