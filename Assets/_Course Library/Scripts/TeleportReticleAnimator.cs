using UnityEngine;

public class TeleportReticleAnimator : MonoBehaviour
{
    [Header("Spin Settings")]
    public float rotationSpeed = 45f; // Degrees per second

    [Header("Pulse Settings")]
    public float pulseSpeed = 2f;     // Oscillations per second
    public float pulseScale = 0.2f;   // Scale amount

    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        // Spin
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);

        // Pulse
        float scaleOffset = Mathf.Sin(Time.time * pulseSpeed * Mathf.PI * 2f) * pulseScale;
        transform.localScale = initialScale + Vector3.one * scaleOffset;
    }
}
