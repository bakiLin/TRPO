using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ManageSound()
    {
        audioManager.audioIsPlayingProperty.Value = audioManager.audioIsPlayingProperty.Value ? false : true;
    }
}
