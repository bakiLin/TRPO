using UnityEngine;

public class PopUpButton : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            _animator.SetBool("PlayerIn", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            _animator.SetBool("PlayerIn", false);
    }
}
