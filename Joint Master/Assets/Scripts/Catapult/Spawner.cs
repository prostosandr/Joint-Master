using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Projectile _prefab;
    [SerializeField] private int _capacity;
    [SerializeField] private int _maxSize;

    private ObjectPool<Projectile> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Projectile>(
            createFunc: () => CreateShell(),
            actionOnGet: (projectile) => ActOnGet(projectile),
            actionOnRelease: (projectile) => projectile.gameObject.SetActive(false),
            actionOnDestroy: (projectile) => Destroy(projectile.gameObject),
            collectionCheck: true,
            defaultCapacity: _capacity,
            maxSize: _maxSize);
    }

    public void Spawn()
    {
        if(_pool.CountActive < _capacity)
        {
            Projectile projectile = _pool.Get();

            projectile.gameObject.SetActive(true);
            projectile.transform.position = _spawnPoint.position;
            projectile.StartLifeCycle();
        }
    }

    private Projectile CreateShell()
    {
        Projectile projectile = Instantiate(_prefab);
        projectile.transform.parent = _container;

        return projectile;
    }

    private void ActOnGet(Projectile projectile)
    {
        projectile.Deactivated += ReleaseShell;
    }

    private void ReleaseShell(Projectile projectile)
    {
        projectile.Deactivated -= ReleaseShell;

        _pool.Release(projectile);
    }
}