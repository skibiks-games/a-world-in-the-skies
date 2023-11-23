using UnityEngine;

public class GameController : MonoBehaviour
{
    private static PlayerMovement PlayerMovement => PlayerMovement.Instance;
    private Transform _playerTransform;

    [SerializeField] private float gameMoveSpeed;

    private void Start() {
        _playerTransform = PlayerMovement.transform;
    }

    private void Update() {
        if (_playerTransform.position.y > 5f)
            transform.Translate(Vector3.down * gameMoveSpeed * Time.deltaTime);
        if (_playerTransform.position.y > 4f)
            transform.Translate(Vector3.down * gameMoveSpeed * Time.deltaTime);
        if (_playerTransform.position.y > 3f)
            transform.Translate(Vector3.down * gameMoveSpeed * Time.deltaTime);
    }
}
