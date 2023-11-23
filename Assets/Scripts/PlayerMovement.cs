using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    [SerializeField] private float sideSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private LayerMask platformsLayer;

    private Rigidbody2D _rb;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        Application.targetFrameRate = 60;

        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    private void FixedUpdate() {
        float sideMovement = Input.GetAxis("Horizontal") * sideSpeed * Time.fixedDeltaTime;
        transform.position += Vector3.right * sideMovement;
    }

    private void Jump() {
        _rb.velocity = Vector2.zero;
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == Mathf.Log(platformsLayer.value, 2)) {
            if (_rb.velocity.y <= 0f)
                Jump();
        }
    }
}
