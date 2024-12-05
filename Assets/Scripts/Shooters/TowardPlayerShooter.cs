using UnityEngine;

public class TowardPlayerShooter : Shooter
{

    private PlayerController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdatePlayer();
    }

    public override void Shoot()
    {
        if (!CanShoot()) return;
        lastShootTime = Time.realtimeSinceStartup;

        BaseBullet bullet = PoolManager.Instance.GetOne<BaseBullet>(bulletName);
        bullet.gameObject.transform.position = transform.position;
        bullet.gameObject.transform.rotation = Quaternion.identity;

        // Debug.Log(CalculateDirection());
        // Debug.DrawLine(transform.position, transform.position + (Vector3)CalculateDirection(), Color.red, 2f);

        bullet.Fire(bulletTarget, CalculateDirection().normalized);
    }

    protected Vector2 CalculateDirection()
    {
        if (player == null) UpdatePlayer();

        return player.gameObject.transform.position - gameObject.transform.position;
    }

    private void UpdatePlayer()
    {
        player = FindFirstObjectByType<PlayerController>();
    }
}
