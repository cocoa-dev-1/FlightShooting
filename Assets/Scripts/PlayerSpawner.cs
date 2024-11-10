using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPrefabs;

    private void Start()
    {
        SpawnPlayer(GameManager.Instance.SelectedPlayerType);
    }

    public void SpawnPlayer(CharacterType characterType)
    {
        Instantiate(playerPrefabs[(int)characterType], transform.position, Quaternion.identity);
    }
}
