using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<T>();

                if (instance == null)
                {
                    string name = typeof(T).ToString();
                    // throw new System.Exception($"Singleton {name} instance not found.");
                    Debug.LogError($"Singleton {name} instance not found.");
                    return null;
                }

                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }
}
