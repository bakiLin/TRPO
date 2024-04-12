using UnityEngine;

public class PlatfDisappear : MonoBehaviour
{
    private Material _material;
    private Color _color;

    private void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        _color = _material.color;
        _color.a = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        _material.color = _color;

        Destroy(GetComponent<PlatfDisappear>());
    }
}
