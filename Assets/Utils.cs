using UnityEngine;

public static class Utils 
{
    public static bool TryGetInterface<T>(this GameObject obj, out T result) where T : class
    {
        result = null;
        if (obj == null) return false;

        foreach (var component in obj.GetComponents<MonoBehaviour>())
        {
            if (component is T found)
            {
                result = found;
                return true;
            }
        }
        return false;
    }

}
