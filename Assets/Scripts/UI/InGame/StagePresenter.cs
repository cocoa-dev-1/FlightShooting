using UnityEngine;

public class StagePresenter : MonoBehaviour
{
    [SerializeField] private StageView view;
    [SerializeField] private StageManager model;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        model.StageChanged += OnStageChanged;
        OnStageChanged(1);
    }

    void OnStageChanged(int stageNumber)
    {
        view.SetStage(stageNumber);
    }
}
