using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField] private Pool[] pools;

    private void Start()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i].Initialize(gameObject);
        }
    }

    public GameObject GetOne(string name)
    {
        for (int i = 0; i < pools.Length; i++)
        {
            if (pools[i].Name == name)
            {
                return pools[i].GetOne();
            }
        }

        return null;
    }

    public T GetOne<T>(string name) where T : Component
    {
        for (int i = 0; i < pools.Length; i++)
        {
            if (pools[i].Name == name)
            {
                return pools[i].GetOne<T>();
            }
        }

        return null;
    }

    public void Return(string name, GameObject obj)
    {
        obj.SetActive(false);

        for (int i = 0; i < pools.Length; i++)
        {
            if (pools[i].Name == GetObjName(name))
            {
                pools[i].Return(obj);
                return;
            }
        }
    }

    private string GetObjName(string name)
    {
        return name.Split('(')[0];
    }
}
