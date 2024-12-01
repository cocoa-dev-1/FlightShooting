using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private BaseHealth health;

    void Awake()
    {
        health = GetComponent<BaseHealth>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health.HPChanged += OnHPChanged;
    }

    private void OnHPChanged(int hp)
    {
        if (hp == 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
