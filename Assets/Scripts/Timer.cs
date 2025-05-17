using UnityEngine;

public class Timer : MonoBehaviour
{
    public float totalTime = 120f;
    public static Timer Instance;

    private void Awake()
    {
        Instance = this;
    }

    public bool TryAssignTime(float time)
    {
        if (totalTime >= time)
        {
            totalTime -= time;
            return true;
        }
        return false;
    }
}
