using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GameClear()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
