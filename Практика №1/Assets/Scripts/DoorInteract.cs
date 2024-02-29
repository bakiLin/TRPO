using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour
{
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
