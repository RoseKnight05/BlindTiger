using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float dayDurationSeconds = 5 * 60;
    public float nightDurationSeconds = 3 * 60;
    private float totalCycleTime { get { return dayDurationSeconds + nightDurationSeconds; } }

    /// <summary>
    /// 0.0 - 1.0 value, similar to 24h time (covers one day and one night cycle)
    /// </summary>
    public float time;

    public float dayTime;
    public float nightTime;

    public State state = State.Day;
    public enum State
    {
        Day,
        Night
    }

    [SerializeField] private Transform mainLight;
    [SerializeField] private float defaultTime = 0.4f;
    float rotSpeed = 1.0f;

    private void RotateLight(float t)
    {
        mainLight.transform.eulerAngles = new Vector3(t * 360, mainLight.transform.eulerAngles.y, mainLight.transform.eulerAngles.z);
    }

    private void Start()
    {
        time = defaultTime;
        dayTime = (dayDurationSeconds - time * totalCycleTime) / dayDurationSeconds;
        RotateLight(time);
    }

    private void Update()
    {
        time = Mathf.Repeat(time + Time.deltaTime / totalCycleTime, 1.0f);

        if (time * totalCycleTime > dayDurationSeconds)
        {
            state = State.Night;
            dayTime = 0;
            nightTime = Mathf.Repeat(nightTime + Time.deltaTime / nightDurationSeconds, 1.0f);
            rotSpeed = 180.0f / nightDurationSeconds * Time.deltaTime;
        }
        else
        {
            state = State.Day;
            nightTime = 0;
            dayTime = Mathf.Repeat(dayTime + Time.deltaTime / dayDurationSeconds, 1.0f);
            rotSpeed = 180.0f / dayDurationSeconds * Time.deltaTime;
        }

        mainLight.transform.Rotate(Vector3.right * rotSpeed);
    }

}
