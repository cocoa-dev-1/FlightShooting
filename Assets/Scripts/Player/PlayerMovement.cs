using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float speed = 5f;

    private Vector2 direction = Vector2.zero;
    private bool isMoving = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateManager.Instance.Add(HandleUpdate);
    }

    void HandleUpdate(object sender, EventArgs e)
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

    void OnDestroy()
    {
        UpdateManager.Instance.Remove(HandleUpdate);
    }
}
