using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public CharacterType SelectedPlayerType { get; private set; }

    public void Play(CharacterType selectedPlayerType)
    {
        Debug.Log($"Selected player type: {selectedPlayerType}");

        SelectedPlayerType = selectedPlayerType;
        SceneManager.LoadScene("GameScene");
    }
}
