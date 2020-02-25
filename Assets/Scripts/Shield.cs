using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject _shield;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player)
        {
            player.ShieldPickup(Instantiate(_shield, other.transform));
            Destroy(gameObject);
        }
    }
}
