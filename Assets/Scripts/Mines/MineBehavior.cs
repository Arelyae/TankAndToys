using System.Collections;
using UnityEngine;

public class MineBehavior : MonoBehaviour
{
    public MineRso MineRso;

    private float life;  // The life duration of the mine
    private SpriteRenderer spriteRenderer;
    private Color mineColor;  // The initial color (MineRso.primarColor)
    private Color finalColor;  // The final color (MineRso.finalColor)

    public float flickerDuration;  // How long the mine will flicker at the end of its life

    private void Start()
    {
        // Initialize the mine
        InitializeMine();

        // Start the color transition
        StartColorTransition();
    }

    // Initialize the mine's properties
    private void InitializeMine()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mineColor = MineRso.primarColor;
        finalColor = MineRso.finalColor;
        life = MineRso.life;
        flickerDuration = MineRso.flickerDuration;

        // Set the mine's initial color
        spriteRenderer.color = mineColor;
    }

    // Start the color transition coroutine
    private void StartColorTransition()
    {
        StartCoroutine(ColorTransition(mineColor, finalColor, life));
    }

    // Coroutine to smoothly transition the color
    private IEnumerator ColorTransition(Color fromColor, Color toColor, float duration)
    {
        float elapsedTime = 0f;

        // Loop through the entire duration
        while (elapsedTime < duration)
        {
            // Interpolate the color as usual
            TransitionColor(fromColor, toColor, elapsedTime, duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final color is set
        spriteRenderer.color = toColor;

        // Start flickering when the mine is near the end of its life
        StartFlickerEffect(fromColor, toColor, flickerDuration);

        // Wait until the flickering time is over before handling the disappearance
        yield return new WaitForSeconds(flickerDuration);

        // Handle the disappearance of the mine
        HandleDisappearance();
    }

    // Smoothly transition the color between fromColor and toColor
    private void TransitionColor(Color fromColor, Color toColor, float elapsedTime, float duration)
    {
        spriteRenderer.color = Color.Lerp(fromColor, toColor, elapsedTime / duration);
    }

    // Start the flicker effect at the end of the mine's life
    private void StartFlickerEffect(Color fromColor, Color toColor, float flickerDuration)
    {
        StartCoroutine(FlickerEffect(fromColor, toColor, flickerDuration));
    }

    // Coroutine to flicker between the original and final color for a set duration
    private IEnumerator FlickerEffect(Color fromColor, Color toColor, float flickerDuration)
    {
        float elapsedTime = 0f;
        bool isFromColor = true;

        while (elapsedTime < flickerDuration)
        {
            // Alternate between the two colors
            spriteRenderer.color = isFromColor ? fromColor : toColor;
            isFromColor = !isFromColor; // Toggle between fromColor and toColor

            // Wait for a short duration before switching colors again
            yield return new WaitForSeconds(0.1f); // Adjust flicker speed here

            elapsedTime += 0.1f;
        }

        // Ensure the final color is set after flickering
        spriteRenderer.color = toColor;
    }

    // Handle the disappearance of the mine when its life ends
    private void HandleDisappearance()
    {
        Instantiate(MineRso.explosionType, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleDisappearance();
    }
}
