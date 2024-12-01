using UnityEngine;

public class EnemyMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float speed = 2f;

    private Vector2 direction = Vector2.zero;
    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(speed * Time.deltaTime * direction);
        }
    }

    public void Move(Vector2 direction)
    {
        this.direction = direction;
        isMoving = true;
    }

    public void UpdateDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void Stop()
    {
        isMoving = false;
    }
}
