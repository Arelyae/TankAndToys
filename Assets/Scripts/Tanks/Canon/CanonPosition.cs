using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonPosition : MonoBehaviour
{

    public Transform referenceTransform;

    void Update()
    {
        FollowReferenceTransform();
    }

    private void FollowReferenceTransform()
    {
        if (referenceTransform != null)
        {
            transform.position = referenceTransform.position; // Snap to the referenced transform's position
        }
    }
}
