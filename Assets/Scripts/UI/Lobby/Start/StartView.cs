using UnityEngine;
using UnityEngine.UI;

public class StartView : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private SelectedPlayerData selectedPlayerData;

    private void Start()
    {
        if (startButton != null)
            startButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        if (!selectedPlayerData.IsSelected)
        {
            Debug.Log("Player is not selected");
            return;
        }

        GameManager.Instance.Play();
    }
}
