using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private CharacterType playerType;

    public CharacterType PlayerType => playerType;

    private SpriteRenderer sr;
    private PlayerSelector playerSelector;
    private Color baseColor;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        playerSelector = FindFirstObjectByType<PlayerSelector>();

        playerSelector.OnCharacterSelected += OnCharacterSelected;

        baseColor = sr.color;
        sr.color = new Color(baseColor.r - 0.2f, baseColor.g - 0.2f, baseColor.b - 0.2f);
    }

    private void OnCharacterSelected(CharacterType selectedCharacterType)
    {
        if (selectedCharacterType == playerType)
        {
            sr.color = baseColor;
        }
        else
        {
            sr.color = new Color(baseColor.r - 0.2f, baseColor.g - 0.2f, baseColor.b - 0.2f);
        }
    }

    private void OnMouseUpAsButton()
    {
        playerSelector.SelectCharacter(playerType);
    }
}
