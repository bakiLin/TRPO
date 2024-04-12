using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _cam;

    private Rigidbody _rb;
    private Vector3 _movePosition;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float vert = Input.GetAxisRaw("Vertical");
        float hor = Input.GetAxisRaw("Horizontal");

        _movePosition = (_cam.forward * vert + _cam.right * hor).normalized;
        _movePosition.y = 0f;
    }

    private void FixedUpdate()
    {
        if (_movePosition.magnitude > 0f)
            _rb.MovePosition(_rb.position + _movePosition * _speed * Time.fixedDeltaTime);
    }
}
