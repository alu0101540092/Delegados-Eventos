using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI scoreText;
  [SerializeField] private TextMeshProUGUI rewardText;

  private void Start()
  {
    if (ScoreManager.Instance != null)
    {
      scoreText.text = $"Puntuación: {ScoreManager.Instance.GetScore()}";
      ScoreManager.Instance.OnScoreChanged += UpdateScoreText;
      ScoreManager.Instance.OnRewardEarned += ShowReward;
    }
  }

  private void OnDestroy()
  {
    if (ScoreManager.Instance != null)
    {
      ScoreManager.Instance.OnScoreChanged -= UpdateScoreText;
      ScoreManager.Instance.OnRewardEarned -= ShowReward;
    }
  }

  private void UpdateScoreText(int newScore)
  {
    scoreText.text = $"Puntuación: {newScore}";
  }

  private void ShowReward()
  {
    rewardText.text = "¡Recompensa obtendida!";
    StartCoroutine(HideRewardAfterDelay());
  }

  private IEnumerator HideRewardAfterDelay()
  {
    yield return new WaitForSeconds(3f);
    rewardText.text = "";
  }
}
