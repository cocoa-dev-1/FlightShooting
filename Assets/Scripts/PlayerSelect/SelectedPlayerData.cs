using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectedPlayerData", menuName = "Scriptable Objects/SelectedPlayerData")]
public class SelectedPlayerData : ScriptableObject
{
    [field: SerializeField] public PlayerType SelectedPlayerType { get; private set; }
    [field: SerializeField] public bool IsSelected { get; private set; } = false;

    public event Action<PlayerType> PlayerChanged;

    private void OnEnable()
    {
        SelectedPlayerType = PlayerType.FIRST;
        IsSelected = false;
    }

    public void SelectPlayer(PlayerType playerType)
    {
        SelectedPlayerType = playerType;
        IsSelected = true;

        PlayerChanged?.Invoke(playerType);
    }
}
