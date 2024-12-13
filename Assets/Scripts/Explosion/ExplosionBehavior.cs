using System.Collections;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    [Header("Explosion Data")]
    public ExplosionRso explosionRso; // Reference to the ExplosionRso, which holds all the necessary values

    [Header("Behavior")]
    private float originalSize;  // The original size of the object
    private float targetSize;    // The target size to transition to
    private float time;          // The time to transition to the target size

    [Header("Appearance")]
    private Color firstColor;    // The first color (start color)
    private Color secondColor;   // The second color (target color during size transition)
    private Color dissappearanceColor; // The color when the object disappears

    private Vector3 initialSize; // The initial size of the object (set to originalSize at start)
    private Color initialColor;  // The initial color of the object (set to firstColor at start)
    private Renderer objectRenderer; // Reference to the renderer to change the color
    private bool isTransitioning = false; // To control if the transition is already happening

    private void Start()
    {
        // Fetch values from ExplosionRso
        if (explosionRso != null)
        {
            originalSize = explosionRso.originalSize;
            targetSize = explosionRso.targetSize;
            time = explosionRso.time;
            firstColor = explosionRso.firstColor;
            secondColor = explosionRso.secondColor;
            dissappearanceColor = explosionRso.dissappearanceColor;
        }
        else
        {
            Debug.LogWarning("ExplosionRso is not assigned!");
        }

        // Set the initial values from the fetched variables
        initialSize = new Vector3(originalSize, originalSize, originalSize);  // Assuming uniform size (x = y = z)
        initialColor = firstColor;
        transform.localScale = initialSize; // Set the object's initial size
        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material.color = initialColor; // Set the object's initial color

        StartTransition();
    }

    // Start the size and color transition
    public void StartTransition()
    {
        if (!isTransitioning)
        {
            StartCoroutine(TransitionCoroutine());
        }
    }

    private IEnumerator TransitionCoroutine()
    {
        isTransitioning = true;
        float elapsedTime = 0f;

        // Transition from the initial size to target size while changing color
        while (elapsedTime < time)
        {
            float t = elapsedTime / time;

            // Smooth transition for size and color
            transform.localScale = Vector3.Lerp(initialSize, new Vector3(targetSize, targetSize, targetSize), t);
            objectRenderer.material.color = Color.Lerp(initialColor, secondColor, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Set the final size and color after the transition
        transform.localScale = new Vector3(targetSize, targetSize, targetSize);
        objectRenderer.material.color = secondColor;

        // Wait a moment and transition to the final color
        yield return new WaitForSeconds(0.5f);

        // Transition to disappearance color
        elapsedTime = 0f;
        while (elapsedTime < time)
        {
            float t = elapsedTime / time;
            objectRenderer.material.color = Color.Lerp(secondColor, dissappearanceColor, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Set the final disappearance color
        objectRenderer.material.color = dissappearanceColor;

        // Handle disappearance (destroy or deactivate the object)
        HandleDisappearance();
    }

    // Handle disappearance (destroy or deactivate the object)
    private void HandleDisappearance()
    {
        Destroy(gameObject); // Destroy the object after the transition
    }
}
