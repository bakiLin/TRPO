using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Destroy(gameObject);
    }
}
