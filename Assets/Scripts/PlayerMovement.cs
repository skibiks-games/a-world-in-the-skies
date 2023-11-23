using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    [SerializeField] AudioClip jumpSound;
    [SerializeField] private float sideSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private LayerMask platformsLayer;
    [SerializeField] private GameObject gameOverPanel;

    private ScoreCounter _scoreCounter;
    private Rigidbody2D _rb;
    private AudioSource _audioSource;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        Application.targetFrameRate = 60;

        _scoreCounter = GetComponent<ScoreCounter>();
        _rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (transform.position.y < -5.5f) {
            GameOver();
        }
    }

    private void FixedUpdate() {
        float sideMovement = Input.GetAxis("Horizontal") * sideSpeed * Time.fixedDeltaTime;
        transform.position += Vector3.right * sideMovement;
    }

    private void Jump() {
        _rb.velocity = Vector2.zero;
        
        _audioSource.PlayOneShot(jumpSound, 0.1f);
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == Mathf.Log(platformsLayer.value, 2)) {
            if (_rb.velocity.y <= 0.1f)
                Jump();
        }
    }

    private void GameOver() {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        _scoreCounter.SetGameOverUI();
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
