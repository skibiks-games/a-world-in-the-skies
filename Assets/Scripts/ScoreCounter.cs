using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int score;

    [SerializeField] private LayerMask coinsLayer;

    private void Start() {
        score = 0;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == Mathf.Log(coinsLayer.value, 2)) {
            score++;
            Destroy(collision.gameObject);
        }
    }
}
