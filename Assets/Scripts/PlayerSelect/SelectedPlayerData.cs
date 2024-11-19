using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectedPlayerData", menuName = "Scriptable Objects/SelectedPlayerData")]
public class SelectedPlayerData : ScriptableObject
{
    [SerializeField] private PlayerType basePlayerType = PlayerType.FIRST;
    [SerializeField] private bool baseIsSelected = false;

    public PlayerType SelectedPlayerType { get; private set; }
    public bool IsSelected { get; private set; }

    public event Action<PlayerType> PlayerChanged;

    private void OnEnable()
    {
        SelectedPlayerType = basePlayerType;
        IsSelected = baseIsSelected;
    }

    public void SelectPlayer(PlayerType playerType)
    {
        SelectedPlayerType = playerType;
        IsSelected = true;

        PlayerChanged?.Invoke(playerType);
    }
}
