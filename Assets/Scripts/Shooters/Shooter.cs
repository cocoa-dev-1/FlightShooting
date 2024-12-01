using UnityEngine;

public class Shooter : MonoBehaviour, IShootable
{
    [SerializeField] protected string bulletName;
    [SerializeField] protected string bulletTarget;

    [SerializeField] protected float shootCoolTime = 3.0f;
    protected float lastShootTime = 0f;

    public virtual void Shoot()
    {
        if (!CanShoot()) return;
        lastShootTime = Time.realtimeSinceStartup;

        BaseBullet bullet = PoolManager.Instance.GetOne<BaseBullet>(bulletName);
        bullet.gameObject.transform.position = transform.position;
        bullet.gameObject.transform.rotation = transform.rotation;

        bullet.Fire(bulletTarget, Vector2.up);
    }

    public bool CanShoot()
    {
        if (lastShootTime + shootCoolTime < Time.realtimeSinceStartup)
            return true;

        return false;
    }
}
