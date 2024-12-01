using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    [SerializeField] protected new string name;
    [SerializeField] protected float spead;
    [SerializeField] protected int power;
    protected string target;

    public abstract void Fire(string target, Vector2 dir);

    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Wall"))
        {
            PoolManager.Instance.Return(name, gameObject);
            return;
        }

        if (target == null || !coll.CompareTag(target))
            return;

        if (coll.TryGetComponent(out IDamageable component))
        {
            component.Hit(power);
            PoolManager.Instance.Return(name, gameObject);
        }
    }
}
