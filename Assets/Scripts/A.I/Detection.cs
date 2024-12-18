using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.Events;

public class Detection : MonoBehaviour
{
    public UnityEvent OnPlayerBeingSeen;
    public UnityEvent OnPlayerSeen;
    public UnityEvent OnPlayerExitingSight;

    public LayerMask detectionLayerMask; // Specify layers the raycast can detect
    public Transform rayCastSpawn;
    public Vector2 rayDirection;
    public bool seesPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tank")
        {
            Debug.Log("Player has been seen");
            OnPlayerBeingSeen.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Tank")
        {
            Debug.Log("Player is in field of view");
            ObstaclesCheck(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tank")
        {
            Debug.Log("Player is not being seen");
            OnPlayerExitingSight.Invoke();
        }
    }

    private void Update()
    {
        FiringAtPlayer();
    }


    public void FiringAtPlayer()
    {
        if (seesPlayer)
        {
            OnPlayerSeen.Invoke();
        }
    }

    public void ObstaclesCheck(Collider2D collision)
    {

        rayDirection = (collision.transform.position - rayCastSpawn.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(rayCastSpawn.position, rayDirection, Mathf.Infinity, detectionLayerMask);

        Debug.DrawRay(rayCastSpawn.position, rayDirection * 10, Color.red); 

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Tank")
            {
                seesPlayer = true;
                return;
            }
            else
            {
                seesPlayer = false;
                return;
            }
        }

    }

}
