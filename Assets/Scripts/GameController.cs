using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _scoreText;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _menu;

    private int _score = 0;
    private bool _isStarted = false;

    private void Awake()
    {
        _startButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
        {
            _isStarted = true;
            _menu.SetActive(false);
        });
    }

    public void IncreaseScore(int increment)
    {
        _score += increment;
        _scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + _score;
    }

    public bool IsGameStarted()
    {
        return _isStarted;
    }
}
