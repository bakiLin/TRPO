using System.Collections;
using UnityEngine;

public class FallDetect : MonoBehaviour
{
    [SerializeField] private float _timer;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMove _movement;

    private void Start() => ES3AutoSaveMgr.Current.Save();

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Body")
            StartCoroutine(LoadSave());
    }

    private IEnumerator LoadSave()
    {
        _movement.enabled = false;

        _animator.SetTrigger("Fade");

        yield return new WaitForSeconds(_timer);

        ES3AutoSaveMgr.Current.Load();

        yield return new WaitForSeconds(1f);

        _movement.enabled = true;
    }
}
