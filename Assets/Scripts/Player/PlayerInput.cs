using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private IMovable playerMovement;

    void Start()
    {
        playerMovement = GetComponent<IMovable>();
    }

    private void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();

        if (direction == Vector2.zero)
        {
            playerMovement.Stop();
            return;
        }
        playerMovement.Move(direction);
    }
}
