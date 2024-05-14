using UniRx;
using UnityEngine;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject window;
    public TextMeshProUGUI timerText;
    public int timeInSeconds;

    private CompositeDisposable disposable = new CompositeDisposable();
    private string addText = "Время: ";

    private void Start()
    {
        SetTimerText();
        StartTimer();
        ChangeTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = addText + timeInSeconds;
    }

    private void StartTimer()
    {
        Observable.Timer(TimeSpan.FromSeconds(timeInSeconds))
            .Subscribe(_ =>
            {
                TimeOverText();

                window.SetActive(true);
                Time.timeScale = 0f;
            }).AddTo(disposable);
    }

    private void ChangeTimerText()
    {
        Observable.EveryUpdate()
            .Sample(TimeSpan.FromSeconds(1f))
            .Subscribe(_ =>
            {
                timeInSeconds--;
                SetTimerText();

                if (timeInSeconds == 0) TimeOverText();
            }).AddTo(disposable);
    }

    private void TimeOverText()
    {
        timerText.text = "Время вышло";
        disposable.Clear();
    }

    private void OnDisable()
    {
        disposable.Clear();
    }
}
