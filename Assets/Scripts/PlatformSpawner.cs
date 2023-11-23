using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] float spawnRate = 5;
    [SerializeField] float y = 5;

    [SerializeField] float startX = 3;
    [SerializeField] float endX = -3;
    [SerializeField] GameObject prefab;
    
    public void Start()
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        while(true)
        {
            Instantiate(prefab, new Vector3(Random.Range(startX,endX), y, 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
        
        
    }
}

