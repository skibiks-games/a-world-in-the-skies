using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] float spawnRate = 1;

    public void Start() {
        StartCoroutine("Timer");
    }
    IEnumerator Timer() {
        for(;;) {
            Debug.Log("es");
            //yield return new WaitForSeconds(spawnRate);
        }
    }
}

