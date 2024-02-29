using I2.Loc;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [Header("TMPro objects")] 
    [SerializeField] private Localize _sentence;
    [SerializeField] private Localize _name;
    [SerializeField] private Localize _option1;
    [SerializeField] private Localize _option2;
    [Space]

    [Header("Gameobjects")]
    [SerializeField] private GameObject _skipButton;
    [SerializeField] private GameObject _optionButton1;
    [SerializeField] private GameObject _optionButton2;
    [SerializeField] private GameObject _doorClosed;
    [SerializeField] private GameObject _doorOpen;
    [SerializeField] private GameObject _doorInteract;
    [Space]

    [Header("Dialogue branches")]
    [SerializeField] private string[] _branch1;
    [SerializeField] private string[] _branch2;
    [SerializeField] private string[] _branch3;
    [Space]

    [Header("Answer options")]
    [SerializeField] private string[] _allOptions;
    [Space]

    [SerializeField] PlayerMove _movementScript;

    private string[] _currentBranch;

    private int _count = 0;
    private int _optionCount = 0;

    private void Start()
    {
        _currentBranch = _branch1;

        _sentence.Term = _currentBranch[_count];
        _name.Term = "Fox";
    }

    public void SkipSentence()
    {
        _count++;

        if (_count != _currentBranch.Length)
        {
            _sentence.Term = _currentBranch[_count];

            if (_currentBranch[_count] == "Blank Area")
                OptionStart();
        }
        else 
        {
            Transform dialogueBox = _skipButton.transform.parent;
            dialogueBox.gameObject.SetActive(false);
            _movementScript.enabled = true;
            _doorClosed.SetActive(false);
            _doorOpen.SetActive(true);
            _doorInteract.SetActive(true);
        }
    }

    private void OptionStart()
    {
        _name.Term = "Racoon";

        _skipButton.SetActive(false);
        _optionButton1.SetActive(true);
        _optionButton2.SetActive(true);

        _option1.Term = _allOptions[_optionCount];
        _option2.Term = _allOptions[_optionCount + 1];
        _optionCount += 2;
    }

    private void OptionOver()
    {
        _name.Term = "Fox";

        _skipButton.SetActive(true);
        _optionButton1.SetActive(false);
        _optionButton2.SetActive(false);

        _count++;
        _sentence.Term = _currentBranch[_count];
    }

    public void Option1()
    {
        OptionOver();
    }

    public void Option2()
    {
        if (_count == 2)
            _currentBranch = _branch2;

        if (_count == 5)
            _currentBranch = _branch3;

        OptionOver();
    }
}
