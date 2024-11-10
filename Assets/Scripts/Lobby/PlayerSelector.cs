using System;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    private CharacterType selectedCharacterType;
    private bool isSelected = false;

    public event Action<CharacterType> OnCharacterSelected;

    private void Start()
    {
        OnCharacterSelected?.Invoke(selectedCharacterType);
    }

    public void SelectCharacter(CharacterType characterType)
    {
        if (!isSelected) isSelected = true;

        selectedCharacterType = characterType;
        OnCharacterSelected?.Invoke(selectedCharacterType);
    }

    public void OnStartClicked()
    {
        if (!isSelected) return;

        GameManager.Instance.Play(selectedCharacterType);
    }
}
