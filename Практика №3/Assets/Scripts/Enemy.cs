using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private Transform playerTransform;
    private Health playerHealth;
    private CompositeDisposable disposable = new CompositeDisposable();

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        playerTransform = player.transform;
        playerHealth = player.GetComponent<Health>();
    }

    private void Start()
    {
        gameObject.OnTriggerEnter2DAsObservable()
            .Where(_ => _.tag == "Player")
            .Subscribe(_ =>
            {
                playerHealth.healthProperty.Value--;
                Destroy(gameObject);
            }).AddTo(disposable);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime); 
    }

    private void OnDisable()
    {
        disposable.Clear();
    }
}
