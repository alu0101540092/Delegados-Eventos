using UnityEngine;

public class CollectibleShield : MonoBehaviour
{
  public enum ShieldType { Type1, Type2 }
  public ShieldType shieldType = ShieldType.Type1;
  public int points => shieldType == ShieldType.Type1 ? 5 : 10;

  private void Reset()
  {
    GetComponent<Collider>().isTrigger = true;
  }

  public void Collect()
  {
    Debug.Log($"{name} recolectado ({shieldType}), +{points} puntos");
    ScoreManager.Instance.AddScore(points);
    gameObject.SetActive(false);
  }
}
