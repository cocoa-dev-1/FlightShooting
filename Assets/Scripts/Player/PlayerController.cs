using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private BaseHealth health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health.HPChanged += OnHPChanged;
    }

    private void OnHPChanged(int hp)
    {
        if (hp == 0)
        {

        }
    }
}
