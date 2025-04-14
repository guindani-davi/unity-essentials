using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Tooltip("Duration of a full day-night cycle in seconds")]
    [SerializeField] private float dayDuration = 120f; // 2 minutes by default

    [Tooltip("Starting rotation (0-1 where 0 is sunrise)")]
    [Range(0f, 1f)]
    [SerializeField] private float startTimeOfDay = 0.25f; // Morning by default

    [Tooltip("Should the cycle automatically start?")]
    [SerializeField] private bool autoStart = true;

    private float currentTime;
    private bool isCycleActive;

    private void Start()
    {
        currentTime = startTimeOfDay;
        isCycleActive = autoStart;

        UpdateSunRotation();
    }

    private void Update()
    {
        if (!isCycleActive) return;

        // Advance time
        currentTime += Time.deltaTime / dayDuration;
        currentTime %= 1f; // Wrap around to keep between 0-1

        UpdateSunRotation();
    }

    private void UpdateSunRotation()
    {
        // Convert time (0-1) to rotation (0-360 degrees)
        // 0.25f = midday, 0.75f = midnight
        float angle = currentTime * 360f;

        // Rotate the directional light
        transform.rotation = Quaternion.Euler(new Vector3(angle, -90f, 0f));
    }

    // Public methods to control the cycle
    public void StartCycle()
    {
        isCycleActive = true;
    }

    public void PauseCycle()
    {
        isCycleActive = false;
    }

    public void ToggleCycle()
    {
        isCycleActive = !isCycleActive;
    }

    public void SetTimeOfDay(float time)
    {
        currentTime = Mathf.Clamp01(time);
        UpdateSunRotation();
    }
}
