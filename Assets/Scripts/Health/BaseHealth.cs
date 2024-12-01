using System;
using UnityEngine;

public class BaseHealth : MonoBehaviour, IDamageable
{
    public event Action<int> HPChanged;

    [SerializeField] protected int maxHP;
    protected int currentHP;
    public int CurrentHP { get => currentHP; }

    public void OnEnable()
    {
        currentHP = maxHP;
    }

    public void Hit(int damage)
    {
        if (damage < 0) return;

        currentHP -= damage;
        if (currentHP < 0) currentHP = 0;

        HPChanged?.Invoke(currentHP);
    }
}
