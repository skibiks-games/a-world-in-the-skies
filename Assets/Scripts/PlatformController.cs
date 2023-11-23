using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float speed;

    [Tooltip("value 0 - 1")] [SerializeField] private float coinChance;
    [SerializeField] private GameObject coinPrefab;

    private void Start() {
        if (Random.value < coinChance)
            Instantiate(coinPrefab, transform.position + Vector3.up * .5f, Quaternion.identity, transform);
    }

    private void Update() {
        transform.Translate(Vector2.down * Time.deltaTime * speed);

        if (transform.position.y < -10f)
            Destroy(gameObject);
    }
}
