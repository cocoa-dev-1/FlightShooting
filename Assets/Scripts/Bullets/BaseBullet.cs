using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    [SerializeField] protected float spead;

    public abstract void Fire(Vector2 dir);
}
