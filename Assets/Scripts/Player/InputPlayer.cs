using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputPlayer : MonoBehaviour
{

    public UnityEvent OnLandMine;
    public UnityEvent OnFire;


    void Start()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float playerLandMine = Input.GetAxis("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLandMine();
        PlayerFireBullet();
    }

    public void PlayerLandMine()
    {

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Player attempted to Land a mine");

        }
    }

    public void PlayerFireBullet()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Player attempted to fire");
            OnFire.Invoke();

        }
    }
}
