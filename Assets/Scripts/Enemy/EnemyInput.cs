using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    private IMovable movable;

    private void Start()
    {
        movable = GetComponent<IMovable>();
    }

    void FindMovement()
    {
        movable = GetComponent<IMovable>();
    }

    void OnEnable()
    {
        if (movable == null) FindMovement();

        movable.Move(Vector2.up);
    }

    void OnDisable()
    {
        if (movable == null) return;
        movable.Stop();
    }
}
