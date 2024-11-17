using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPrefabs;
    [SerializeField] private SelectedPlayerData selectedPlayerData;

    private void Start()
    {
        SpawnPlayer(selectedPlayerData.SelectedPlayerType);
    }

    public void SpawnPlayer(PlayerType characterType)
    {
        Instantiate(playerPrefabs[(int)characterType], transform.position, Quaternion.identity);
    }
}
