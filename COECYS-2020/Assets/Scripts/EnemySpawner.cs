using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        var timeToSpawn = Random.Range(3f, 7f);
        Invoke(nameof(SpawnEnemy), timeToSpawn);
    }

    private void SpawnEnemy()
    {
        if (_gameManager.isGamePlaying)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation);   
        }
        var timeToSpawn = Random.Range(3f, 7f);
        Invoke(nameof(SpawnEnemy), timeToSpawn);
    }
}
