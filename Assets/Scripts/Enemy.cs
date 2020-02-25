using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _shot;
    [SerializeField] private Transform _gunPosition;
    [SerializeField] private float _shotDelay;
    [SerializeField] private GameObject _enemyExplosion;

    private float nextShot;
    private Rigidbody _rigidbody;
    private Player _player;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _player = FindObjectOfType<Player>();
        if (_player)
        {
            transform.LookAt(_player.transform);
        }
        _rigidbody.velocity = transform.forward * _speed;
    }

    private void Update()
    {
        if (Time.time > nextShot)
        {
            nextShot = Time.time + _shotDelay;
            Instantiate(_shot, _gunPosition.position, _gunPosition.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameBoundary" || other.gameObject.tag == "ShotEnemy")
        {
            return;
        }
        
        Instantiate(_enemyExplosion, transform.position, Quaternion.identity);
       
        Destroy(gameObject);
    }
}
