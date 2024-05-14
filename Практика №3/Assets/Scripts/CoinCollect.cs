using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI menuCoinText;

    private ReactiveCommand<GameObject> coinCommand = new ReactiveCommand<GameObject>();
    private CompositeDisposable disposable = new CompositeDisposable();
    private int coins;
    private string addText = "Монеты: ";

    private void Start()
    {
        CreateCommand();
        CoinTrigger();
    }

    private void CreateCommand()
    {
        coinCommand.Subscribe(coin =>
        {
            coins++;
            coinText.text = addText + coins;
            menuCoinText.text = $"Вы собрали {coins} монет";
            Destroy(coin);
        }).AddTo(disposable);
    }

    private void CoinTrigger()
    {
        gameObject.OnTriggerEnter2DAsObservable()
            .Where(_ => _.tag == "Coin")
            .Subscribe(_ =>
            {
                coinCommand.Execute(_.gameObject);
            }).AddTo(disposable);
    }

    private void OnDisable()
    {
        disposable.Clear();
    }
}
