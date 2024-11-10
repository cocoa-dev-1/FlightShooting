using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float speed = 5f;

    private Vector2 direction = Vector2.zero;
    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            transform.position += speed * Time.deltaTime * (Vector3)direction;
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
