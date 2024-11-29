using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private IShootable gun;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gun = GetComponentInChildren<IShootable>();
    }

    void Update()
    {
        gun.Shoot();
    }
}
