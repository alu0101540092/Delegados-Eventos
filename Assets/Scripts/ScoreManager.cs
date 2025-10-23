using UnityEngine;

public class ScoreManager : MonoBehaviour
{
  public static ScoreManager Instance { get; private set; }
  private int score = 0;

  private void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(gameObject);
      return;
    }
    Instance = this;
  }

  public void AddScore(int points)
  {
    score += points;
    Debug.Log($"Puntuación actual: {score}");
  }
}
