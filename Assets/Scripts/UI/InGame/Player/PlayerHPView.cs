using TMPro;
using UnityEngine;

public class PlayerHPView : MonoBehaviour
{
    public const string HP_PREFIX = "Player HP : ";

    [SerializeField] private TextMeshProUGUI HPText;

    public void SetHP(int value)
    {
        HPText.text = HP_PREFIX + value.ToString();
    }
}
