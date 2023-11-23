using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] private GameObject coinPrefab;

    private static PlayerMovement PlayerMovement => PlayerMovement.Instance;

    private BoxCollider2D _collider;
    private Transform _playerTF;

    private float _minDistanceToJump;

    private void Start() {
        _collider = GetComponent<BoxCollider2D>();
        _playerTF = PlayerMovement.transform;

        _minDistanceToJump = (transform.localScale.y + _playerTF.localScale.y) * .49f;

        Instantiate(coinPrefab, transform.position + Vector3.up * .5f, Quaternion.identity, transform);
    }

    private void Update() {
        _collider.enabled = _playerTF.position.y > transform.position.y + _minDistanceToJump;

        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
}
