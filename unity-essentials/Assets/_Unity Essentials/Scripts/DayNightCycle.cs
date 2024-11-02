using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Total time for a day to pass (in real-world seconds)
    [Tooltip("Time in seconds for a full day/night cycle.")]
    public float dayDurationInSeconds = 30f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the rotation amount based on the time elapsed and duration of a full day
        float rotationSpeed = 360f / dayDurationInSeconds * Time.deltaTime;

        // Rotate the light around the x-axis to simulate the sun's movement
        transform.Rotate(Vector3.right, rotationSpeed);
        
    }
}