using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] float spawnRate = 5;
    [SerializeField] float y;
    
    [SerializeField] float startX = 0;
    [SerializeField] float endX = 10;
    [SerializeField] GameObject prefab;
    
    public void Start()
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        while(true)
        {
            Instantiate(prefab, new Vector3(Random.Range(startX,endX), 0, 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
        
        
    }
}

