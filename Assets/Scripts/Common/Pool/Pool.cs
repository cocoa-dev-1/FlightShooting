using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pool
{
    [SerializeField] private string name;

    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private int size = 20;

    private Stack<GameObject> pool;

    public string Name => name;

    public void Initialize()
    {
        pool = new Stack<GameObject>();

        for (int i = 0; i < size; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab, parent);
            obj.SetActive(false);
            pool.Push(obj);
        }
    }

    public GameObject GetOne()
    {
        if (pool.Count == 0)
        {
            GameObject obj = GameObject.Instantiate(prefab, parent);
            return obj;
        }

        GameObject result = pool.Pop();
        result.SetActive(true);

        return result;
    }

    public T GetOne<T>() where T : Component
    {
        GameObject obj = GetOne();

        if (obj.TryGetComponent(out T component))
        {
            return component;
        }

        return null;
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        pool.Push(obj);
    }

    public static Pool Create(GameObject prefab, Transform parent, int size)
    {
        Pool pool = new()
        {
            prefab = prefab,
            parent = parent,
            size = size
        };
        pool.Initialize();

        return pool;
    }
}
