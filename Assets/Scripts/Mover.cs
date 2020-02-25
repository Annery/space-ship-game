using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _direction = 1f;

    private void Awake()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * _speed * _direction;
    }
}
