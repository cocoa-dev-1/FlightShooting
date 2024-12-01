using UnityEngine;

public class StraightShooter : MonoBehaviour, IShootable
{
    [SerializeField] private string bulletName;
    [SerializeField] private string bulletTarget;

    [SerializeField] private float shootCoolTime = 3.0f;
    private float lastShootTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {
        // Debug.Log(Time.realtimeSinceStartup);
    }

    public void Shoot()
    {
        if (!CanShoot()) return;
        lastShootTime = Time.realtimeSinceStartup;

        BaseBullet bullet = PoolManager.Instance.GetOne<BaseBullet>(bulletName);
        bullet.gameObject.transform.position = transform.position;
        bullet.gameObject.transform.rotation = transform.rotation;

        bullet.Fire(bulletTarget, Vector2.up);
    }

    private bool CanShoot()
    {
        if (lastShootTime + shootCoolTime < Time.realtimeSinceStartup)
            return true;

        return false;
    }
}
