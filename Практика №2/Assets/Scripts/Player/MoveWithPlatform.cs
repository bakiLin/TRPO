using UnityEngine;

public class MoveWithPlatform : MonoBehaviour
{
    private Rigidbody _rb;
    private PlatfMove _platfMove;
    private bool _onPlatform = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MovingPlatform")
        {
            _onPlatform = true;
            _platfMove = other.GetComponent<PlatfMove>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MovingPlatform")
        {
            _onPlatform = false;
            _platfMove = null;
        }
    }

    private void Start() => _rb = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        if (_onPlatform)
            _rb.MovePosition(_rb.position + _platfMove.speed * Time.fixedDeltaTime);
    }
}