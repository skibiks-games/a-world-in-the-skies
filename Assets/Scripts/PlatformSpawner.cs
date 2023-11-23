using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] float spawnDistance = 2f;
    [SerializeField] float minXDistance = 1f;
    [SerializeField] float maxXDistance = 4f;
    [SerializeField] float y = 5f;

    [SerializeField] float startX = -4f;
    [SerializeField] float endX = 4f;
    [SerializeField] GameObject prefab;

    private Transform _lastPlatformTF;
    
    public void Start() {
        SpawnPlatform(Vector3.up * y);
    }

    private void Update() {
        if(y - _lastPlatformTF.position.y >= spawnDistance)
            SpawnPlatform(_lastPlatformTF.position);
    }

    private void SpawnPlatform(Vector3 lastPos) {
        float xDistance = Random.Range(minXDistance, maxXDistance);
        xDistance *= Random.value < .5f ? -1f : 1f;
        float xPos = lastPos.x + xDistance;
        xPos = Mathf.Clamp(xPos, startX, endX);
        if (xPos == startX || xPos == endX)
            xPos = lastPos.x - xDistance;
        GameObject platformGO = Instantiate(prefab, new Vector3(xPos, lastPos.y + spawnDistance, 0f), Quaternion.identity, transform);
        _lastPlatformTF = platformGO.transform;
    }
}

