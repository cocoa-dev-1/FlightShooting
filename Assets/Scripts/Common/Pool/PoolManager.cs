using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField] private Pool[] pools;

    private void Start()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i].Initialize();
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
            if (pools[i].Name == name)
            {
                pools[i].Return(obj);
                return;
            }
        }
    }
}
