using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

public class LangManager : MonoBehaviour
{
    [SerializeField] private Image _buttonImg;

    [SerializeField] private Sprite _englishSprite;
    [SerializeField] private Sprite _russianSprite;

    private bool isRussian = false;

    private void Start()
    {
        LocalizationManager.CurrentLanguage = "English";
    }

    public void ChangeLang()
    {
        if (!isRussian)
        {
            LocalizationManager.CurrentLanguage = "Russian";
            _buttonImg.sprite = _russianSprite;

            isRussian = true;
        }
        else
        {
            LocalizationManager.CurrentLanguage = "English";
            _buttonImg.sprite = _englishSprite;

            isRussian = false;
        }
            
    }
}
