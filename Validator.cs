using UnityEngine;

public static class Validator
{
    public static void Validate(ref float currentValue, float minValue, float maxValue)
    {
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);

        if (minValue >= maxValue)
        {
            minValue = maxValue - 1;
        }
    }

    public static void Validate(ref int currentValue, int minValue, int maxValue)
    {
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);

        if (minValue >= maxValue)
        {
            minValue = maxValue - 1;
        }
    }
}