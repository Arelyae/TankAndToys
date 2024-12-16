using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detection : MonoBehaviour
{
    public UnityEvent OnPlayerBeingSeen;
    public UnityEvent OnPlayerSeen;
    public UnityEvent OnPlayerExitingSight;

    public LayerMask detectionLayerMask; // Optional layer mask to filter the raycast

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
        Debug.Log("Player is in field of view");

        if (collision.gameObject.tag == "Tank")
        {
            // Cast a ray from this object's position to the player's position
            Vector2 rayDirection = (collision.transform.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, Mathf.Infinity, detectionLayerMask);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Tank")
                {
                    Debug.Log("Raycast hit the player (Tank)");
                    OnPlayerSeen.Invoke();
                }
                else
                {
                    Debug.Log("Raycast hit something else, stopping detection.");
                }
            }
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
}
