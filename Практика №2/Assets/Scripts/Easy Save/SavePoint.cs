using UnityEngine;

public class SavePoint : MonoBehaviour
{
    [SerializeField] private GameObject _saveWindow;

    private bool _interactable;

    private void OnTriggerEnter(Collider other) => PlayerInteract(other);

    private void OnTriggerExit(Collider other) => PlayerInteract(other);

    private void PlayerInteract(Collider other)
    {
        if (other.name == "Body")
        {
            _interactable = !_interactable;
            _saveWindow.SetActive(_interactable);
        }
    }

    private void Update()
    {
        if (_interactable && Input.GetKeyDown(KeyCode.Y))
        {
            _saveWindow.SetActive(false);

            ES3AutoSaveMgr.Current.Save();

            Destroy(GetComponent<SavePoint>());
        }
    }
}
