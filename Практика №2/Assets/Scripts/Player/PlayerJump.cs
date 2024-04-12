using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _gravity;

    private Rigidbody _rb;
    private bool _jumped;
    private int _collisions;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform" || other.tag == "MovingPlatform")
            _collisions++;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Platform" || other.tag == "MovingPlatform")
            _collisions--;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_collisions > 0 && Input.GetButtonDown("Jump"))
            _jumped = true;
    }

    private void FixedUpdate()
    {
        if (_jumped)
        {
            _jumped = false;

            _rb.AddForce(transform.up * _jumpPower, ForceMode.Impulse);
        }

        _rb.AddForce(Physics.gravity * _gravity, ForceMode.Acceleration);
    }
}
