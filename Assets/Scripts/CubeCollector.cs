using UnityEngine;

public class CubeCollector : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    var shield = other.GetComponent<CollectibleShield>();
    if (shield != null)
    {
      shield.Collect();
    }
  }

  private void OollisionEnter(Collision collision)
  {
    var shield = collision.collider.GetComponent<CollectibleShield>();
    if (shield != null)
    {
      shield.Collect();
    }
  }
}
