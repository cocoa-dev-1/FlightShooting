using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private CharacterType playerType;

    public CharacterType PlayerType => playerType;

    private SpriteRenderer sr;
    private PlayerSelector playerSelector;
    private Color baseColor;
    private const float colorChangeAmount = 0.4f;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        playerSelector = FindFirstObjectByType<PlayerSelector>();

        playerSelector.OnCharacterSelected += OnCharacterSelected;

        baseColor = sr.color;
        ChangeColor(false);
    }

    private void ChangeColor(bool selected)
    {
        if (selected)
        {
            sr.color = baseColor;
        }
        else
        {
            sr.color = new Color(baseColor.r - colorChangeAmount, baseColor.g - colorChangeAmount, baseColor.b - colorChangeAmount);
        }
    }

    private void OnCharacterSelected(CharacterType selectedCharacterType)
    {
        if (selectedCharacterType == playerType)
        {
            ChangeColor(true);
        }
        else
        {
            ChangeColor(false);
        }
    }

    private void OnMouseUpAsButton()
    {
        playerSelector.SelectCharacter(playerType);
    }
}
