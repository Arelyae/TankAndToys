using System.Collections;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    [Header("Explosion Data")]
    public ExplosionRso explosionRso; // Reference to the ExplosionRso, which holds all the necessary values

    private Vector3 initialSize;      // The initial size of the object (set to originalSize at start)
    private Color initialColor;       // The initial color of the object (set to firstColor at start)
    private Renderer objectRenderer;  // Reference to the renderer to change the color

    private void Start()
    {
        if (explosionRso == null)
        {
            Debug.LogWarning("ExplosionRso is not assigned!");
            return;
        }

        // Initialize size and color
        initialSize = new Vector3(explosionRso.originalSize, explosionRso.originalSize, explosionRso.originalSize); // Assuming uniform size
        initialColor = explosionRso.firstColor;

        // Set object size and color
        transform.localScale = initialSize;
        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material.color = initialColor;

        StartTransition();
    }

    // Start the size and color transition
    public void StartTransition()
    {
        StartCoroutine(TransitionCoroutine());
    }

    private IEnumerator TransitionCoroutine()
    {
        float elapsedTime = 0f;

        // Transition from the initial size to target size while changing color
        while (elapsedTime < explosionRso.time)
        {
            float t = elapsedTime / explosionRso.time;

            // Use animation curves from the ScriptableObject
            float sizeMultiplier = explosionRso.sizeCurve.Evaluate(t);
            float colorMultiplier = explosionRso.colorCurve.Evaluate(t);

            // Interpolate size and color
            transform.localScale = Vector3.Lerp(initialSize, new Vector3(explosionRso.targetSize, explosionRso.targetSize, explosionRso.targetSize), sizeMultiplier);
            objectRenderer.material.color = Color.Lerp(initialColor, explosionRso.secondColor, colorMultiplier);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Finalize size and color
        transform.localScale = new Vector3(explosionRso.targetSize, explosionRso.targetSize, explosionRso.targetSize);
        objectRenderer.material.color = explosionRso.secondColor;

        // Wait before transitioning to disappearance color
        yield return new WaitForSeconds(0.5f);

        // Transition to disappearance color
        elapsedTime = 0f;
        while (elapsedTime < explosionRso.time)
        {
            float t = elapsedTime / explosionRso.time;
            float colorMultiplier = explosionRso.colorCurve.Evaluate(t); // Reuse the color curve for fading out
            objectRenderer.material.color = Color.Lerp(explosionRso.secondColor, explosionRso.dissappearanceColor, colorMultiplier);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Set disappearance color
        objectRenderer.material.color = explosionRso.dissappearanceColor;

        // Handle disappearance
        HandleDisappearance();
    }

    // Handle disappearance (destroy or deactivate the object)
    private void HandleDisappearance()
    {
        Destroy(gameObject); // Destroy the object after the transition
    }
}
