using System.Collections;
using UnityEngine;

public class PlayerHPPresenter : MonoBehaviour
{
    [SerializeField] private PlayerHPView view;
    private BaseHealth model;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(IEFindPlayerHealth());
    }

    void Init()
    {
        model.HPChanged += OnPlayerHealthUpdated;
    }

    void OnPlayerHealthUpdated(int hp)
    {
        view.SetHP(hp);
    }

    IEnumerator IEFindPlayerHealth()
    {
        while (model == null)
        {
            yield return new WaitForSeconds(0.5f);

            var player = FindFirstObjectByType<PlayerController>();
            model = player.GetComponent<BaseHealth>();
        }

        Init();
        OnPlayerHealthUpdated(model.CurrentHP);
    }
}
