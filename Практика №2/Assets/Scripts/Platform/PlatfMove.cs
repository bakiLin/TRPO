using System.Collections;
using UnityEngine;

public class PlatfMove : MonoBehaviour
{
    [SerializeField] private float _time;

    public Vector3 speed;

    private void Start() => StartCoroutine(ChangeDirection());

    private void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime;
    }

    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(_time);

            speed *= -1f;
        }
    }
}
