using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int score;
    public int bestScore;

    private static string bestScorePPId = "BestScore";

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private LayerMask coinsLayer;

    private void Start() {
        score = 0;

        if (PlayerPrefs.HasKey(bestScorePPId))
            bestScore = PlayerPrefs.GetInt(bestScorePPId);
        else {
            PlayerPrefs.SetInt(bestScorePPId, 0);
            bestScore = 0;
        }
        UpdateUI();
    }

    private void UpdateUI() {
        scoreText.text = $"score: {score}";
        bestScoreText.text = $"best score: {bestScore}";
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == Mathf.Log(coinsLayer.value, 2)) {
            score++;
            if (score >= bestScore) {
                bestScore = score;
                PlayerPrefs.SetInt(bestScorePPId, bestScore);
            }
            UpdateUI();
            Destroy(collision.gameObject);
        }
    }
}
