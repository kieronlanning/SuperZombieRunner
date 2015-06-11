using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour
{
    public void ManipulateTime(float newTime, float duration)
    {
        if (Time.timeScale == 0f)
            Time.timeScale = .1f;

        StartCoroutine(FadeTo(newTime, duration));
    }

    IEnumerator FadeTo(float value, float time)
    {
        // Using Time.deltaTime / time means it will stop smoothly based on game time, not as fast as it can be executed.

        for (var t = 0f; t < 1f; t += Time.deltaTime/time)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, value, t);

            if (Mathf.Abs(value - Time.timeScale) < .01f)
            {
                Time.timeScale = value;
                return false;
            }

            yield return null;
        }
    }
}