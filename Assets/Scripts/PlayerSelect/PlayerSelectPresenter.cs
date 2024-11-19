using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class PlayerSelectPresenter : MonoBehaviour
{
    [SerializeField] private PlayerSelectView view;
    [SerializeField] private SelectedPlayerData model;

    void Start()
    {
        view.PlayerSelected += model.SelectPlayer;
        model.PlayerChanged += view.OnPlayerChanged;

        if (model.IsSelected)
            view.OnPlayerChanged(model.SelectedPlayerType);
    }
}
