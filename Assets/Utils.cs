using UnityEngine;

public static class Utils 
{
    public static bool TryGetInterface<T>(this GameObject obj, out T result) where T : class
    {
        result = null;
        if (obj == null) return false;

        foreach (MonoBehaviour component in obj.GetComponents<MonoBehaviour>())
        {
            result = component as T;
            if (result != null)
            {
                return true;
            }
        }
        return false;
    }

}
