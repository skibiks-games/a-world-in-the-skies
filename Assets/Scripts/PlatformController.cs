using UnityEngine;

[SelectionBase]
public class PlatformController : MonoBehaviour
{
    [Tooltip("value 0 - 1")] [SerializeField] private float coinChance;
    [SerializeField] private GameObject coinPrefab;

    private void Start() {
        if (Random.value < coinChance)
            Instantiate(coinPrefab, transform.position + Vector3.up * .5f, Quaternion.identity, transform);
    }
}
