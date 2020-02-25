using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _xMin, _xMax, _zMin, _zMax;
    [SerializeField] private float _tilt;
    [SerializeField] private GameObject _shot;
    [SerializeField] private GameObject _smallShot;
    [SerializeField] private Transform _gunPosition;
    [SerializeField] private Transform _smallGunRightPosition;
    [SerializeField] private Transform _smallGunLeftPosition;
    [SerializeField] private GameObject _playerExplosion;
    [SerializeField] private float _shotDelay;
    [SerializeField] private float _smallShotDelay;

    private float _nextShot;
    private float _nextSmallShot;
    private Rigidbody _rigidbody;
    private Stack<GameObject> _shields = new Stack<GameObject>();
    private GameController _controller;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _controller = GameObject
            .FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();
    }

    private void Update()
    {
        if (!_controller.IsGameStarted())
        {
            return;
        }

        if (Input.GetButton("Fire1") && Time.time > _nextShot)
        {
            _nextShot = Time.time + _shotDelay;
            Instantiate(_shot, _gunPosition.position, Quaternion.identity);
        }

        if (Input.GetButton("Fire2") && Time.time > _nextSmallShot)
        {
            _nextSmallShot = Time.time + _smallShotDelay;
            Instantiate(_smallShot, _smallGunRightPosition.position, Quaternion.Euler(0, 45, 0));
            Instantiate(_smallShot, _smallGunLeftPosition.position, Quaternion.Euler(0, -45, 0));
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        _rigidbody.velocity = new Vector3(moveHorizontal, 0, moveVertical) * _speed;

        float newX = Mathf.Clamp(_rigidbody.position.x, _xMin, _xMax);
        float newZ = Mathf.Clamp(_rigidbody.position.z, _zMin, _zMax);
        float newY = _rigidbody.position.y;

        _rigidbody.position = new Vector3(newX, newY, newZ);

        _rigidbody.rotation = Quaternion.Euler(_rigidbody.velocity.z * _tilt, 0, -_rigidbody.velocity.x * _tilt);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameBoundary" || other.gameObject.tag == "ShotPlayer" || other.CompareTag("PlayerShield") || other.CompareTag("PlayerShieldBooster"))
        {
            return;
        }
        if (_shields.Count > 0)
        {
            //print(other.name);
            Destroy(_shields.Pop());
            return;
        }
        Instantiate(_playerExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void ShieldPickup(GameObject shield)
    {
        _shields.Push(shield);
    }
}