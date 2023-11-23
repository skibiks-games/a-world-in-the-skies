using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update() {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
}
