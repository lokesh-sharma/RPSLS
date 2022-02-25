using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    static bool applicationIsQuitting;
    static T instance;
    public static T Instance
    {
        get
        {
            if (applicationIsQuitting) return null;

            if (instance == null)
            {
                GameObject obj = new GameObject
                {
                    name = typeof(T).Name
                };
                instance = obj.AddComponent<T>();
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        applicationIsQuitting = true;
    }
}
