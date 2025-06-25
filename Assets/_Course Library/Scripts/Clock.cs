using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [Header("Clock Hand Transforms")]
    [SerializeField] private Transform hourHand;
    [SerializeField] private Transform minuteHand;
    [SerializeField] private Transform secondHand;

    [Header("Directional Light Reference")]
    [SerializeField] private GameObject directionalLightObject;

    private DayNightCycle dayNightCycle;

    void Start()
    {
        if (directionalLightObject != null)
        {
            dayNightCycle = directionalLightObject.GetComponent<DayNightCycle>();
        }
    }

    void Update()
    {
        if (dayNightCycle == null) return;

        // Get the current time of day as a value from 0 to 1
        float t = dayNightCycle.timeOfDay;

        // Convert to hours, minutes, seconds (24-hour format)
        float totalSeconds = t * 24f * 60f * 60f;
        int hours = (int)(totalSeconds / 3600f);
        int minutes = (int)((totalSeconds % 3600f) / 60f);
        int seconds = (int)(totalSeconds % 60f);

        // Calculate hand angles
        float hourAngle = ((hours % 12) + minutes / 60f) * 30f;      // 360/12 = 30
        float minuteAngle = (minutes + seconds / 60f) * 6f;          // 360/60 = 6
        float secondAngle = seconds * 6f;                            // 360/60 = 6

        // Apply rotations
        if (hourHand != null) hourHand.localRotation = Quaternion.Euler(hourAngle, 0, 0);
        if (minuteHand != null) minuteHand.localRotation = Quaternion.Euler(minuteAngle, 0, 0);
        if (secondHand != null) secondHand.localRotation = Quaternion.Euler(secondAngle, 0, 0);
    }
}
