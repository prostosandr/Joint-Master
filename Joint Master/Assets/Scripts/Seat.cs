using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Seat : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private PlayerInput _playerInput;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _playerInput.QPressed += Sway;
    }

    private void OnDisable()
    {
        _playerInput.QPressed -= Sway;
    }

    private void Sway()
    {
        Vector3 force = Vector3.forward * _force;

        _rigidbody.AddForce(force);
    }
}
