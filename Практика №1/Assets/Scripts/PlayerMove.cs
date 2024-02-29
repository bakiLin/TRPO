using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private Vector2 _movePos = Vector2.zero;
    private Rigidbody2D _rb;

    private bool _moveHor = false;
    private bool _moveVert = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        _moveHor = CheckMovement(hor, _moveHor, _moveVert);
        _moveVert = CheckMovement(vert, _moveVert, _moveHor);

        _movePos.x = SetMovement(_moveHor, hor, 3f, 2f);
        _movePos.y = SetMovement(_moveVert, vert, 1f, 0f);

        _animator.SetFloat("Speed", Mathf.Abs(_movePos.x) + Mathf.Abs(_movePos.y));
        _animator.SetFloat("Horizontal", _movePos.x);
        _animator.SetFloat("Vertical", _movePos.y);
    }
    
    private bool CheckMovement(float dirValue, bool currDir, bool oppositeDir)
    {
        bool temp = false;

        if (Mathf.Abs(dirValue) > 0 && !oppositeDir)
            temp = true;
        else if (Mathf.Abs(dirValue) == 0 && currDir)
            temp = false;

        return temp;
    }

    private float SetMovement(bool currDir, float dirValue, float num1, float num2)
    { 
        if (currDir)
        {
            if (dirValue == 1) _animator.SetFloat("Last Direction", num1);
            else _animator.SetFloat("Last Direction", num2);

            return dirValue;
        }
        else
            return 0f;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movePos * _speed * Time.fixedDeltaTime);
    }
}
