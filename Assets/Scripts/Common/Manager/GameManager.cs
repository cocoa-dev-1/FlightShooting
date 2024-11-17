using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }
}
