using UnityEngine;

public class StraightBullet : BaseBullet
{
    [SerializeField] private Rigidbody2D rb;

    public override void Fire(Vector2 dir)
    {
        rb.AddForce(dir * spead);
    }
}
