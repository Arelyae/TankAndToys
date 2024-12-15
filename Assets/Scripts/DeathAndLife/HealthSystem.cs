using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public GameObject objectToDestroy;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            Destroy(objectToDestroy);
            Debug.Log("Object was destroyed by" + collision.gameObject.name);
        }
    }
}
