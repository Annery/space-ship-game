using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private GameObject[] _hazards;

    private float _nextSpawn;
    private GameController _controller;

    private void Awake()
    {
        _controller = GameObject
            .FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();
    }
    private void Update()
    {
        if (Time.time <= _nextSpawn || !_controller.IsGameStarted())
        {
            return;
        }

        float yPosition = transform.position.y;
        float zPosition = transform.position.z;
        float xPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
        Vector3 randomPosition = new Vector3(xPosition, yPosition, zPosition);

        Instantiate(_hazards[Random.Range(0, _hazards.Length)], randomPosition, Quaternion.identity);
        _nextSpawn = Time.time + Random.Range(_minDelay, _maxDelay);
    }
}
