using UnityEngine;

public static class Vector3RoundSCRIPT
{
    public static Vector3 Round(this Vector3 vector, int decimalPlaces)
    {
        float multiplier = Mathf.Pow(10, decimalPlaces);
        return new Vector3(
            Mathf.Round(vector.x * multiplier) / multiplier,
            Mathf.Round(vector.y * multiplier) / multiplier,
            Mathf.Round(vector.z * multiplier) / multiplier
        );
    }
}
