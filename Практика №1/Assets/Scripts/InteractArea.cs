using UnityEngine;

public class PopUpButton : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMovement;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject dialogueBox;

    private Animator buttonAnimator;
    private bool playerEntered;

    private void Awake() => buttonAnimator = GetComponent<Animator>();

    private void OnTriggerEnter2D(Collider2D collision) => PlayerTrigger(true);

    private void OnTriggerExit2D(Collider2D collision) => PlayerTrigger(false);

    private void PlayerTrigger(bool state)
    {
        buttonAnimator.SetBool("PlayerIn", state);
        playerEntered = state;
    }

    private void Update()
    {
        if (playerEntered && Input.GetKeyUp(KeyCode.E))
        {
            playerAnimator.SetFloat("Speed", 0f);
            playerMovement.enabled = false;
            buttonAnimator.SetBool("PlayerIn", false);
            dialogueBox.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
