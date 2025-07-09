using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Target _target;
    [SerializeField] private float _enemySpawnTime = 2f;

    private ObjectPool<Enemy> _enemyPool;
    private float _spawnBorderX;
    private float _spawnBorderZ;

    private void Awake()
    {
        _enemyPool = new ObjectPool<Enemy>(
            createFunc: () => Instantiate(_enemyPrefab),
            actionOnGet: (enemy) => enemy.gameObject.SetActive(true),
            actionOnRelease: (enemy) => enemy.gameObject.SetActive(false),
            actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
            defaultCapacity: 1
        );

        _spawnBorderX = transform.localScale.x / 2f;
        _spawnBorderZ = transform.localScale.z / 2f;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy(_enemySpawnTime));
    }

    private IEnumerator SpawnEnemy(float time)
    {
        WaitForSeconds timeDelay = new WaitForSeconds(time);

        while (enabled)
        {
            float spawnPositionX = Random.Range(-_spawnBorderX, _spawnBorderX);
            float spawnPositionY = 1f;
            float spawnPositionZ = Random.Range(-_spawnBorderZ, _spawnBorderZ);

            yield return timeDelay;

            Enemy enemy = _enemyPool.Get();
            enemy.transform.position = transform.position + new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
            enemy.StartMovement(_target);
        }
    }
}