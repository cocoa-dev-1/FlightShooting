using System;
using System.Collections;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private StageInfo[] stageInfos;
    [SerializeField] private int currentStageIndex = 0;
    [SerializeField] private int currentLeftEnemyCount = 0;

    public event Action<int> StageChanged;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLeftEnemyCount = stageInfos[currentStageIndex].SpawnQuantity;
        StartCoroutine(IESpawnEnemies(stageInfos[currentStageIndex]));
    }

    IEnumerator IESpawnEnemies(StageInfo stageInfo)
    {
        for (int i = 0; i < stageInfo.SpawnQuantity; i++)
        {
            yield return new WaitForSeconds(stageInfo.SpawnCoolTime);

            int enemyIndex = UnityEngine.Random.Range(0, stageInfo.SpawnableEnemyList.Length);
            GameObject enemyPrefab = enemyPrefabs[enemyIndex];
            EnemyController enemyController = PoolManager.Instance.GetOne<EnemyController>(enemyPrefab.name);
            enemyController.EnemyDead += OnEnemyDead;
            enemyController.gameObject.transform.position = new Vector3(GetRandomSpawnPosition(), 4, 0);
            enemyController.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
    }

    float GetRandomSpawnPosition()
    {
        return UnityEngine.Random.Range(-2.3f, 2.3f);
    }

    void NextStage()
    {
        currentStageIndex++;

        if (currentStageIndex == stageInfos.Length)
        {
            GameManager.Instance.GameClear();
            return;
        }

        StageChanged?.Invoke(currentStageIndex + 1);

        currentLeftEnemyCount = stageInfos[currentStageIndex].SpawnQuantity;
        StartCoroutine(IESpawnEnemies(stageInfos[currentStageIndex]));
    }

    void OnEnemyDead()
    {
        currentLeftEnemyCount--;

        if (currentLeftEnemyCount == 0) NextStage();
    }
}
