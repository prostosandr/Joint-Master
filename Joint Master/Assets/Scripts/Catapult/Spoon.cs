using System;
using UnityEngine;

[RequireComponent(typeof(SpringJoint))]
public class Spoon : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float maxSpring;
    [SerializeField] private float minSpring;

    private SpringJoint _joint;

    public event Action Charged;

    private void Awake()
    {
        _joint = GetComponent<SpringJoint>();
    }

    private void OnEnable()
    {
        _playerInput.WPressed += Fire;
        _playerInput.EPressed += Relax;
    }

    private void OnDisable()
    {
        _playerInput.WPressed -= Fire;
        _playerInput.EPressed -= Relax;
    }

    private void Fire()
    {
        _joint.spring = maxSpring;
        _joint.connectedBody.WakeUp();
    }

    private void Relax()
    {
        _joint.spring = minSpring;
        _joint.connectedBody.WakeUp();

        Charged?.Invoke();
    }
}