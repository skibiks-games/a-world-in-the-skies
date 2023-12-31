using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float sideSpeed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }

        float sideMovement = Input.GetAxis("Horizontal") * sideSpeed * Time.deltaTime;
        transform.position += Vector3.right * sideMovement;
    }

    private void Jump() {
        _rb.velocity = Vector2.zero;
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
