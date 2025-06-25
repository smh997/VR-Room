using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Tooltip("Duration of a full day in seconds")]
    [SerializeField] private float dayDurationInSeconds = 60f;

    [Header("Light Colors")]
    [SerializeField] private Color dawnColor = new Color(1f, 0.6f, 0.3f);   // Soft orange
    [SerializeField] private Color noonColor = Color.white;                  // Bright white
    [SerializeField] private Color duskColor = new Color(1f, 0.4f, 0.2f);    // Reddish orange
    [SerializeField] private Color nightColor = new Color(0.1f, 0.1f, 0.3f); // Dark blue

    private float rotationSpeed;
    public float timeOfDay; // 0 to 1, now public
    private Light dirLight;

    void Start()
    {
        rotationSpeed = 360f / dayDurationInSeconds;
        dirLight = GetComponent<Light>();
    }

    void Update()
    {
        // Rotate the light
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);

        // Update time of day (0 to 1)
        timeOfDay += Time.deltaTime / dayDurationInSeconds;
        if (timeOfDay > 1f) timeOfDay -= 1f;

        // Set light color based on time of day
        if (dirLight != null)
        {
            dirLight.color = EvaluateLightColor(timeOfDay);
        }
    }

    private Color EvaluateLightColor(float t)
    {
        // t: 0 = dawn, 0.25 = noon, 0.5 = dusk, 0.75 = night, 1 = dawn
        if (t < 0.25f) // Dawn to Noon
            return Color.Lerp(dawnColor, noonColor, t / 0.25f);
        else if (t < 0.5f) // Noon to Dusk
            return Color.Lerp(noonColor, duskColor, (t - 0.25f) / 0.25f);
        else if (t < 0.75f) // Dusk to Night
            return Color.Lerp(duskColor, nightColor, (t - 0.5f) / 0.25f);
        else // Night to Dawn
            return Color.Lerp(nightColor, dawnColor, (t - 0.75f) / 0.25f);
    }

    private void OnValidate()
    {
        if (dayDurationInSeconds <= 0)
        {
            dayDurationInSeconds = 1f; // prevent divide-by-zero
        }

        rotationSpeed = 360f / dayDurationInSeconds;
    }
}
