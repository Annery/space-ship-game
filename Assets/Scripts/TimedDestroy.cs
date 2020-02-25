using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    [SerializeField] private float _destroyAfterTime = 1f;

    private void Awake()
    {
        Destroy(gameObject, _destroyAfterTime);
    }
}
