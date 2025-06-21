using System.Collections;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private Spoon _spoon;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private float _spawnTime;

    private void Start()
    {
        _spawner.Spawn();
    }

    private void OnEnable()
    {
        _spoon.Charged += Spawn;
    }

    private void OnDisable()
    {
        _spoon.Charged -= Spawn;
    }

    private void Spawn()
    {
        var wait = new WaitForSeconds(_spawnTime);

        StartCoroutine(CreateItem(wait));
    }

    private IEnumerator CreateItem(WaitForSeconds wait)
    {
        yield return wait;

        _spawner.Spawn();
    }
}