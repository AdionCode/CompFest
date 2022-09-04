using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] Transform[] SpawnPosition;
    [SerializeField] GameObject[] Monster;
    int MaxMonster;
    int MaxSpawnPosition;

    bool isGameOver = false;

    [SerializeField] float SpawnDelay;

    [SerializeField] TimeManager Time;

    private void Start()
    {
        // Get length
        MaxSpawnPosition = SpawnPosition.Length;
        MaxMonster = Monster.Length;

        // Coroutine Start
        StartCoroutine(SpawnEnemys());
    }

    // Coroutine function stopping spawn enemy for a minutes
    IEnumerator SpawnEnemys()
    {
        while (!isGameOver)
        {
            Debug.Log("Spawn enemy work");
            int randomPos = Random.Range(0, MaxSpawnPosition);
            Instantiate(Monster[Random.Range(0, MaxMonster)], SpawnPosition[randomPos].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(SpawnDelay);
        }
    }
}
