using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour {
    [SerializeField] private float speed;

    private void Update() {
        transform.Translate(Vector2.down * Time.deltaTime * speed);

        if (transform.position.y < -10f)
            Destroy(gameObject);
    }
}
