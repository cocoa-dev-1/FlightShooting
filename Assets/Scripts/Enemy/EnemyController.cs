using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private IShootable[] guns;
    private BaseHealth health;

    public event Action EnemyDead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        guns = GetComponentsInChildren<IShootable>();
        health = GetComponent<BaseHealth>();
        health.HPChanged += OnHPChanged;
    }

    void OnDisable()
    {
        RemoveAllDeadEvent();
    }

    void Update()
    {
        foreach (IShootable gun in guns)
        {
            gun.Shoot();
        }
    }

    private void OnHPChanged(int hp)
    {
        if (hp == 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        EnemyDead?.Invoke();
        PoolManager.Instance.Return(name, gameObject);
    }

    private void RemoveAllDeadEvent()
    {
        if (EnemyDead == null) return;

        foreach (Delegate handler in EnemyDead.GetInvocationList())
        {
            EnemyDead -= (Action)handler;
        }
    }
}
