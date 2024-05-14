using TMPro;
using UniRx;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject window;
    public TextMeshProUGUI healthText;
    public IntReactiveProperty healthProperty = new IntReactiveProperty();

    private CompositeDisposable disposable = new CompositeDisposable();
    private string addText = "Çהמנמגüו: ";

    private void Start()
    {
        SetHealthText();

        healthProperty.Subscribe(_ =>
        {
            SetHealthText();

            if (healthProperty.Value == 0)
            {
                window.SetActive(true);
                Time.timeScale = 0f;
            }
        }).AddTo(disposable);
    }

    private void SetHealthText()
    {
        healthText.text = addText + healthProperty.Value;
    }

    private void OnDisable()
    {
        disposable.Clear();
    }
}
