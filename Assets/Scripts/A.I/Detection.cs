using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detection : MonoBehaviour
{
    public UnityEvent OnPlayerBeingSeen;
    public UnityEvent OnPlayerSeen;
    public UnityEvent OnPlayerExitingSight;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            Debug.Log("Player has been seen");
            OnPlayerBeingSeen.Invoke();
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            Debug.Log("Player is being seen");
            OnPlayerSeen.Invoke();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            Debug.Log("Player is not being seen");
            OnPlayerExitingSight.Invoke();
        }
    }
}
