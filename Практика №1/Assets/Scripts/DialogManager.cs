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
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject _skipButton;
    [SerializeField] private GameObject _optionButton1;
    [SerializeField] private GameObject _optionButton2;
    [SerializeField] private GameObject _doorClosed;
    [SerializeField] private GameObject _doorOpen;
    [SerializeField] private BoxCollider2D door;
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

    private int dialogueLineNumber = 0;
    private int _optionCount = 0;

    private void Start()
    {
        _currentBranch = _branch1;
        _sentence.Term = _currentBranch[dialogueLineNumber];
        _name.Term = "Fox";
    }

    public void SkipSentence()
    {
        dialogueLineNumber++;

        if (dialogueLineNumber != _currentBranch.Length)
        {
            _sentence.Term = _currentBranch[dialogueLineNumber];
            if (_currentBranch[dialogueLineNumber] == "Blank Area") OptionStart();
        }
        else 
        {
            dialogueBox.SetActive(false);
            _movementScript.enabled = true;
            _doorClosed.SetActive(false);
            _doorOpen.SetActive(true);
            door.isTrigger = true;
        }
    }

    private void OptionStart()
    {
        _name.Term = "Racoon";

        OptionButtonState(false);

        _option1.Term = _allOptions[_optionCount];
        _option2.Term = _allOptions[_optionCount + 1];
        _optionCount += 2;
    }

    private void OptionOver()
    {
        _name.Term = "Fox";

        OptionButtonState(true);

        dialogueLineNumber++;
        _sentence.Term = _currentBranch[dialogueLineNumber];
    }

    private void OptionButtonState(bool state)
    {
        _skipButton.SetActive(state);
        _optionButton1.SetActive(!state);
        _optionButton2.SetActive(!state);
    }

    public void Option1() => OptionOver();

    public void Option2()
    {
        if (dialogueLineNumber == 2) _currentBranch = _branch2;
        if (dialogueLineNumber == 5) _currentBranch = _branch3;

        OptionOver();
    }
}