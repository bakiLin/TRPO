using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;

    private Vector2 moveDirection;
    private Rigidbody2D rb;

    private bool isMovingHorizontaly, isMovingVerticaly;
    private int lastMovedDirection;

    private void Start() => rb = GetComponent<Rigidbody2D>();

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        isMovingHorizontaly = horizontal != 0 && !isMovingVerticaly;
        isMovingVerticaly = vertical != 0 && !isMovingHorizontaly;

        moveDirection.x = isMovingHorizontaly ? horizontal : 0f;
        moveDirection.y = isMovingVerticaly ? vertical : 0f;

        animator.SetFloat("Speed", moveDirection.magnitude);
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);

        if (isMovingHorizontaly) lastMovedDirection = horizontal > 0 ? 3 : 2;
        if (isMovingVerticaly) lastMovedDirection = vertical > 0 ? 0 : 1;

        animator.SetFloat("Last Direction", lastMovedDirection);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * moveDirection);
    }
}
