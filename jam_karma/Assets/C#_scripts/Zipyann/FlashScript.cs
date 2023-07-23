using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScript : MonoBehaviour
{
    public float flashInterval = 0.3f; // Time interval between appearing and disappearing (in seconds)
    private bool isFlashing = false;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Start the flashing coroutine
      //  StartFlashing();
    }

    public void StartFlashing()
    {
        if (!isFlashing)
        {
            isFlashing = true;
            StartCoroutine(FlashObject());
        }
    }

    public void StopFlashing()
    {
        if (isFlashing)
        {
            isFlashing = false;
            StopCoroutine(FlashObject());
        }
    }

    private IEnumerator FlashObject()
    {
        while (isFlashing)
        {
            // Show the sprite
            spriteRenderer.enabled = true;

            // Wait for the specified flashInterval
            yield return new WaitForSeconds(flashInterval);

            // Hide the sprite
            spriteRenderer.enabled = false;

            // Wait for the specified flashInterval
            yield return new WaitForSeconds(flashInterval);
        }

        // Make sure the sprite is visible when the flashing is stopped
        spriteRenderer.enabled = true;
    }

    // Customize the flash interval during gameplay if needed
    public void SetFlashInterval(float newInterval)
    {
        flashInterval = newInterval;
    }
}
