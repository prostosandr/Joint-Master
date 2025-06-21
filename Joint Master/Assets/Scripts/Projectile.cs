using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    public event Action<Projectile> Deactivated;

    public void StartLifeCycle()
    {
        var wait = new WaitForSeconds(_lifeTime);

        StartCoroutine(LiveCycle(wait));
    }

    private IEnumerator LiveCycle(WaitForSeconds wait)
    {
        yield return wait;

        Deactivated?.Invoke(this);
    }
}