using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private IMovable playerMovement;
    private IShootable[] playerGuns;

    void Start()
    {
        playerMovement = GetComponent<IMovable>();
        playerGuns = GetComponentsInChildren<IShootable>();
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

    private void OnAttack(InputValue value)
    {
        float isAttack = value.Get<float>();

        if (isAttack != 1f) return;

        foreach (IShootable shootable in playerGuns)
        {
            shootable.Shoot();
        }
    }
}
