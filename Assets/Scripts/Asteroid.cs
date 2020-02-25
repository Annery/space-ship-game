using UnityEngine;

public class Asteroid : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private GameObject _asteroidExplosion;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.angularVelocity = Random.insideUnitSphere * _rotationSpeed;
        _rigidbody.velocity = Vector3.back * Random.Range(_minSpeed, _maxSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameBoundary" || other.gameObject.tag == "Asteroid")
        {
            return;
        }

        /*var explosion =*/
        Instantiate(_asteroidExplosion, transform.position, Quaternion.identity);
        //explosion.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
        if (!other.CompareTag("Player"))
        {
            GameObject
                .FindGameObjectWithTag("GameController")
                .GetComponent<GameController>()
                .IncreaseScore(10);
        }
        Destroy(gameObject);
    }
}
