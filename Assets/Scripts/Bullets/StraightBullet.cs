using UnityEngine;

public class StraightBullet : BaseBullet
{
    private Vector2 dir = Vector2.zero;

    private void Update()
    {
        if (dir == Vector2.zero)
            return;

        transform.Translate(spead * Time.deltaTime * dir);
    }

    public override void Fire(string target, Vector2 dir)
    {
        this.target = target;
        this.dir = dir.normalized;
    }
}
