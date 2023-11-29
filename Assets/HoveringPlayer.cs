using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveringPlayer : MonoBehaviour
{
    public float hoverAmplitude = 0.1f;
    public float hoverSpeed = 1.0f;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Create a hovering effect by scaling the sprite up and down
        float scaleMultiplier = 1.0f + Mathf.Sin(Time.time * hoverSpeed) * hoverAmplitude;
        transform.localScale = originalScale * scaleMultiplier;
    }
}