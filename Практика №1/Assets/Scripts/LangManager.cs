using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

public class LangManager : MonoBehaviour
{
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite englishSprite;
    [SerializeField] private Sprite russianSprite;

    private bool isRussian;

    private void Start() => LocalizationManager.CurrentLanguage = "English";

    public void ChangeLanguage()
    {
        if (isRussian) LanguageChoice("English", englishSprite);
        else LanguageChoice("Russian", russianSprite);

        isRussian = !isRussian;
    }

    private void LanguageChoice(string language, Sprite sprite)
    {
        LocalizationManager.CurrentLanguage = language;
        buttonImage.sprite = sprite;
    }
}
