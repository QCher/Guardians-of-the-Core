using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [Header("Setup spawner")]
    [SerializeField] Creature _prefab;
    [SerializeField] Transform _spawnPoint;
    [Header("Setup pool")]
    [Range(1, 100)] [SerializeField] int _defaultCapacity = 10;
    [Range(1, 10000)] [SerializeField] int _maxSize = 1000;
    private IObjectPool<Creature> _pool;
    private IObjectPool<Creature> Pool =>
        _pool ??= new ObjectPool<Creature>(
            CreateFunc,
            null,
            null,
            null,
            true, _defaultCapacity, _maxSize);

    public void SpawnAt(Vector3 position, Quaternion rotation)
    {
        var pooledObject = Pool.Get(out var creature);
        creature.transform.position = position;
        creature.transform.rotation = rotation;
        creature.Initialization(pooledObject);
    }

    private void Start()
    {
        StartSpawn();
    }

    private async void StartSpawn()
    {
        await SpawnTask();
    }

    async UniTask SpawnTask()
    {
        while (this)
        {
            var random = Random.insideUnitSphere;
            random.y = 0;
            SpawnAt(_spawnPoint.position + 10*random,  Quaternion.identity);
            await UniTask.Delay(6000);
        }
    }

    private Creature CreateFunc()
    {
        return Instantiate(_prefab, _spawnPoint);
    }
}
