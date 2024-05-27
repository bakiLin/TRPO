using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private int time;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject restartButton;

    private void Start()
    {
        StartCoroutine(ChangeTime());
    }

    private IEnumerator ChangeTime()
    {
        while (true) 
        {
            timerText.text = time.ToString();
            yield return new WaitForSeconds(1f);
            time -= 1;

            if (time < 0)
            {
                restartButton.SetActive(true);
                break;
            }
        }
    }
}
