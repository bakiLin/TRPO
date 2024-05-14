using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public BoolReactiveProperty audioIsPlayingProperty = new BoolReactiveProperty();
    public Button audioButton;

    private CompositeDisposable disposable = new CompositeDisposable();
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ChangeColor();

        audioIsPlayingProperty.Subscribe(_ =>
        {
            if (audioIsPlayingProperty.Value) audioSource.Play();
            else audioSource.Stop();

            ChangeColor();
        }).AddTo(disposable);
    }

    private void ChangeColor()
    {
        var color = audioButton.colors;
        color.normalColor = audioIsPlayingProperty.Value ? Color.green : Color.red;
        audioButton.colors = color;
    }

    private void OnDisable()
    {
        disposable.Clear();
    }
}
