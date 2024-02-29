using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private Animator _foxPupUp;
    [SerializeField] private Animator _playerRun;
    [SerializeField] private GameObject _dialogueBox;
    [SerializeField] private PlayerMove _movementScript;

    private bool _playerIn = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") _playerIn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") _playerIn = false;
    }

    private void Update()
    {
        if (_playerIn)
        {
            if (Input.GetKeyUp(KeyCode.E)) 
            {
                _foxPupUp.SetBool("PlayerIn", false);
                _playerRun.SetFloat("Speed", 0f);
                _dialogueBox.SetActive(true);
                _movementScript.enabled = false;
                gameObject.SetActive(false);
            }
        }
    }
}
