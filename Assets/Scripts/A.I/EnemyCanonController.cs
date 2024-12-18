using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanonController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] CanonFunctionTemplate canonFunction;

    [Header("Rotation Settings")]
    public float startAngle;    // Initial angle of patrol rotation
    public float endAngle;      // Final angle of patrol rotation
    public float rotationTime;  // Time to complete one rotation back or forth

    private Coroutine patrolCoroutine; // Reference to the patrol coroutine
    public bool isPlayerVisible;

    private void Update()
    {
        CheckPlayerVisibility();
    }

    public void CheckPlayerVisibility()
    {
        if (isPlayerVisible)
        {
            StopPatrolling(); // Stop patrol when player is visible
            FollowingPlayer();
        }
        else
        {
            PatrolMode();
        }
    }

    public void FollowingPlayer()
    {
        canonFunction.FaceTargetPositon(playerData.playerTransform, transform);
    }

    public void PatrolMode()
    {
        if (patrolCoroutine == null) // Start patrol only if not already patrolling
        {
            patrolCoroutine = StartCoroutine(RotateBackAndForth());
        }
    }

    public void StopPatrolling()
    {
        if (patrolCoroutine != null)
        {
            StopCoroutine(patrolCoroutine); // Stop the active patrol coroutine
            patrolCoroutine = null;
        }
    }

    private IEnumerator RotateBackAndForth()
    {
        while (!isPlayerVisible) // Keep patrolling as long as the player is not visible
        {
            // Rotate from startAngle to endAngle
            yield return RotateOverTime(startAngle, endAngle, rotationTime);

            // Rotate back from endAngle to startAngle
            yield return RotateOverTime(endAngle, startAngle, rotationTime);
        }

        // End patrol if isPlayerVisible becomes true
        patrolCoroutine = null;
    }

    private IEnumerator RotateOverTime(float fromAngle, float toAngle, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Stop immediately if the player becomes visible
            if (isPlayerVisible)
            {
                patrolCoroutine = null; // Reset the coroutine reference
                yield break;
            }

            // Interpolate between the start and end angles
            float currentAngle = Mathf.Lerp(fromAngle, toAngle, elapsedTime / duration);

            // Apply the rotation to the transform
            transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final angle is set precisely
        transform.rotation = Quaternion.Euler(0f, 0f, toAngle);
    }
}
