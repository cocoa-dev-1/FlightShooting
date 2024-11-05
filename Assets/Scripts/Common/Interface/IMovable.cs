using UnityEngine;

public interface IMovable
{
    public void Move(Vector2 direction);

    public void UpdateDirection(Vector2 direction);

    public void Stop();
}
