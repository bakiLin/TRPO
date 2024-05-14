using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 move = new Vector3(horizontal, vertical, 0f).normalized;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + move, speed * Time.deltaTime);

        LimitMovement();
    }

    private void LimitMovement()
    {
        Vector3 temp = transform.position;

        temp.x = Mathf.Clamp(temp.x, -8.4f, 8.4f);
        temp.y = Mathf.Clamp(temp.y, -4.5f, 4.5f);

        transform.position = temp;
    }
}
