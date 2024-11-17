using System;
using UnityEngine;

public class PlayerSelectView : MonoBehaviour
{
    [SerializeField] private PlayerType playerType;

    private SpriteRenderer sr;
    private Color baseColor;
    private const float colorChangeAmount = 0.4f;

    public event Action<PlayerType> PlayerSelected;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();

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

    public void OnPlayerChanged(PlayerType selectedCharacterType)
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
        PlayerSelected?.Invoke(playerType);
    }
}
