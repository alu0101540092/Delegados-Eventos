using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI scoreText;

  private void Start()
  {
    if (ScoreManager.Instance != null)
    {
      scoreText.text = $"Puntuación: {ScoreManager.Instance.GetScore()}";
      ScoreManager.Instance.OnScoreChanged += UpdateScoreText;
    }
  }

  private void OnDestroy()
  {
    if (ScoreManager.Instance != null)
    {
      ScoreManager.Instance.OnScoreChanged -= UpdateScoreText;
    }
  }

  private void UpdateScoreText(int newScore)
  {
    scoreText.text = $"Puntuación: {newScore}";
  }
}
