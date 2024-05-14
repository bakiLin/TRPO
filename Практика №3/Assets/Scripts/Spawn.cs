using System;
using UniRx;
using UnityEngine;
using Random = System.Random;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject coin;
    public float coinSpawnRate;
    public float enemySpawnRate;

    private CompositeDisposable disposable = new CompositeDisposable();
    private Random rand = new Random();

    private void Start()
    {
        SpawnCoin();
        SpawnEnemy();
    }

    private void SpawnCoin()
    {
        Observable.EveryUpdate()
            .Sample(TimeSpan.FromSeconds(coinSpawnRate))
            .Subscribe(_ =>
            {
                Instantiate(coin, GetRandomPosition(), Quaternion.identity);
            }).AddTo(disposable);
    }

    private void SpawnEnemy()
    {
        Observable.EveryUpdate()
            .Sample(TimeSpan.FromSeconds(enemySpawnRate))
            .Subscribe(_ =>
            {
                Instantiate(enemy, GetRandomPosition(), Quaternion.identity);
            }).AddTo(disposable);
    }

    private Vector3 GetRandomPosition()
    {
        float horizontal = rand.Next(-8, 8);
        float vertical = rand.Next(-4, 4);

        return new Vector3(horizontal, vertical, 0f);
    }

    private void OnDisable()
    {
        disposable.Clear();
    }
}
