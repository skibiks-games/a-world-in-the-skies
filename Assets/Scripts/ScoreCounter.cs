using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int score;
    public int maxScore;

    private static string maxScorePPId = "MaxScore";

    [SerializeField] private LayerMask coinsLayer;

    private void Start() {
        score = 0;

        if (PlayerPrefs.HasKey(maxScorePPId))
            maxScore = PlayerPrefs.GetInt(maxScorePPId);
        else {
            PlayerPrefs.SetInt(maxScorePPId, 0);
            maxScore = 0;
        }
    }

    private void UpdateUI() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == Mathf.Log(coinsLayer.value, 2)) {
            score++;
            Destroy(collision.gameObject);
        }
    }
}
