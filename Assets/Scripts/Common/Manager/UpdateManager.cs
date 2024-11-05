using System;
using UnityEngine;

public class UpdateManager : Singleton<UpdateManager>
{
    private event EventHandler updateEvent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        updateEvent?.Invoke(this, EventArgs.Empty);
    }

    public void Add(EventHandler handler)
    {
        updateEvent += handler;
    }

    public void Remove(EventHandler handler)
    {
        updateEvent -= handler;
    }
}
