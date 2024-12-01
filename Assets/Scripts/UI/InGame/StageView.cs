using TMPro;
using UnityEngine;

public class StageView : MonoBehaviour
{
    public const string STAGE_PREFIX = "Stage : ";

    [SerializeField] private TextMeshProUGUI stageText;

    public void SetStage(int stageNumber)
    {
        stageText.text = STAGE_PREFIX + stageNumber.ToString();
    }
}
