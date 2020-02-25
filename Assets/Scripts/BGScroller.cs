using UnityEngine;

public class BGScroller : MonoBehaviour
{

    [SerializeField] private float _speed;

    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        float newPosition = Mathf.Repeat(Time.time*_speed,transform.localScale.y);

        transform.position = _startPosition + Vector3.back * newPosition;
    }
}
